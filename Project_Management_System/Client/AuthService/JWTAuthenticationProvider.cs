using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;


namespace Project_Management_System.Client.AuthService
{
    public class JWTAuthenticationProvider : AuthenticationStateProvider, ILoginService
    {
        private static readonly string TOKENKEY = "TokenKey";
         
        private readonly ILocalStorageService _localStorageService;

        private readonly HttpClient _httpClient;

        private AuthenticationState Anonymous => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public JWTAuthenticationProvider(ILocalStorageService localStorageService,
                                            HttpClient httpClient)
        {
            this._localStorageService = localStorageService;
            this._httpClient = httpClient;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await GetSessionTokenAsync();

            if (string.IsNullOrEmpty(token.Token))
            {
                return Anonymous;
            }

            return BuildAuthenticationState(token.Token);
        }

        public async Task<AccessToken> GetSessionTokenAsync()
        {
            return await _localStorageService.GetItemAsync<AccessToken>(TOKENKEY);
        }

        public AuthenticationState BuildAuthenticationState(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            return Convert.FromBase64String(base64);
        }
        

        public async Task Login(string token)
        {
            var newToken = new AccessToken()
            {
                Token = token
            };

            await _localStorageService.SetItemAsync(TOKENKEY, newToken);

            var authState = BuildAuthenticationState(token);

            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }


        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync(TOKENKEY);

            _httpClient.DefaultRequestHeaders.Authorization = null;

            NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
        }
    }
}