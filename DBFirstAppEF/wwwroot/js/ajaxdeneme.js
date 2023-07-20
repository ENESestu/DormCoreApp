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
            contentType: false,       // Bu üç satýr data kontrolü ile alakalýdýr. 
            processData: false,       //
            success: function (res) {
                console.log(res.html)
                if (res.isValid) {
                    $("#view-all-dorm").html(res.html);
                    //$("#form-modal .modal-body").html('');  // Bu satýrlarýn neden olduðunu anlamadým. Hiç bir þey deðiþmedi.
                    //$("#form-modal .modal-title").html('');
                    $("#form-modal").modal("hide");  // Buradaki hide iþlemi iþlem bittikten sonra ekranýn kapanmasýný saðlýyor.
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