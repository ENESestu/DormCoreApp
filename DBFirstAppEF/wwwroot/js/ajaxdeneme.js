//$("#ajax-deneme").click(function () {
//      $.ajax({
//        type: "GET",
//        url: "/Home/AddOrEdit",
//        success: function (res) {
//            $("#form-modal .modal-body").html(res);
//            $("#form-modal").modal("show");
//        }
//    })
//})

function showInPopupLink(url, title) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal("show");
        }
    })
}

JQueryAjaxPost = form    => {
    try {
        $.ajax({
            type : "POST",
            url : form.action,
            data: new  FormData(form),//
            contentType: false,       // Bu �� sat�r data kontrol� ile alakal�d�r. 
            processData: false,       //
            success: function (res) {
                console.log(res.html)
                if (res.isValid) {
                    $("#view-all-dorm").html(res.html);
                    //$("#form-modal .modal-body").html('');  // Bu sat�rlar�n neden oldu�unu anlamad�m. Hi� bir �ey de�i�medi.
                    //$("#form-modal .modal-title").html('');
                    $("#form-modal").modal("hide");  // Buradaki hide i�lemi i�lem bittikten sonra ekran�n kapanmas�n� sa�l�yor.
                } else {
                    $("#form-modal .modal-body").html(res.html);
                }
            },
            error: function (err) {
                console.log(err)
            }
        })

    } catch (e) {
        console.log(e)
    }
    //to prevent default form submit event 
    return false;
}