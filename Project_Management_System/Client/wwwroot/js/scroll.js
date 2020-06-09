window.scrollToElementId = (elementId) => {
    var element = document.getElementById(elementId);

    if (!element) {
        console.warn('element was not found', elementId);

        return false;
    }

    window.setInterval(element.scrollTop = element.scrollHeight - element.clientHeight, 1);

    console.info('scrolling to element', elementId);

    return true;
}



//function updateScroll() {
//    var element = document.getElementById('scrollUpdate');

//    element.scrollTop = element.scrollHeight;
//}


//setInterval(function updateScroll() {

//    var element = document.getElementById('scrollUpdate');

//    element.scrollTop = element.scrollHeight;

//}, 1);


//const messages = document.getElementById('scrollUpdate');

//function appendMessage() {
//    const messages = document.getElementById('scrollUpdate');
//    const message = document.getElementsByClassName('message')[0];
//    const newMessage = message.cloneNode(true);
//    messages.appendChild(newMessage);
//}



//window.setInterval(function updateScroll() {

//    const messages = document.getElementById('scrollUpdate');
//    // Prior to getting your messages.
//    shouldScroll = messages.scrollTop + messages.clientHeight === messages.scrollHeight;
//    /*
//     * Get your messages, we'll just simulate it by appending a new one syncronously.
//     */
//    //appendMessage();
//    // After getting your messages.
//    if (!shouldScroll) {
//        scrollToBottom();
//    }

//}, 1)

//function scrollToBottom() {
//    const messages = document.getElementById('scrollUpdate');

//    messages.scrollTop = messages.scrollHeight;
//}