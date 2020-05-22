function CloseModal(title, message, type) {
    $("#AddEditEmpModal").modal('hide');
    $("#EditEmpModal").modal('hide');
    return new Promise((resolve) => {
        Swal.fire({
            title: title,
            text: message,
            icon: type,
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'OK'
        }).then((result) => {
            if (result.value) {
                resolve(true);
            } else {
                resolve(false);
            }
        })
    });
}