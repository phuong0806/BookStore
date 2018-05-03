

//$.validator.setDefaults({ ignore: ":hidden:not(select)" })
function readURL(input) {
    let url = URL.createObjectURL(input.files[0]);
    console.log(input.files[0]);
    $('.img-selected')
             .attr('src', url);
    $('.image-selected').text(input.files[0].name);
    $('#img-book').val(input.files[0]);
}
function reset() {
    $('.image-selected').text('...');
    $('.img-selected').attr('src', '/Assets/admin/css/images/alter-image.jpg');
    $('#result .hinh-anh').removeClass('active');
    $('#img-book').val('');
}

$(document).on('click', '#result .hinh-anh', function () {
    var urlImg = $(this).attr('src');
    var idImg = $(this).attr('id');
    $('#result .hinh-anh').removeClass('active');
    $(this).toggleClass('active');
    $('.img-selected').attr('src', urlImg)
    $('#img-book').val(urlImg);
    $('.image-selected').text(idImg);
})

$(document).on('click', '#reset-link', function () {
    reset();
});

$('#CategoryID').chosen();
$('#AuthorID').chosen();
$("#AuthorID").chosen({ no_results_text: "Không tìm thấy :(( " });
$('#AuthorID').trigger('chosen:updated');


$(function () {
    $("#upload-link").on('click', function (e) {
        e.preventDefault();
        $("#upload:hidden").trigger('click');
    });
});

$(document).on('click', '#delete-link', function () {
    if (confirm('Bạn có chắc là xóa hình này?')) {
        var filename = $('#result .hinh-anh.active').attr('src');
        $.ajax({
            type: "POST",
            url: "/Admin/Book/deleteImage",
            dataType: "json",
            data: { filename: filename } ,
            success: function (result) {
                reset();
                console.log(result);
                alert("Xóa thành công");
                var html = "";
                for (var i = 0; i < result.length; i++) {
                    html += "<div class='col-sm-3 a-book'>";
                    html += "<img src=" + result[i].path + " class='hinh-anh' alt='Alternate Text' />";
                    html += "<span class='ten-hinh-anh'>" + result[i].name + "</span>";
                    html += "</div>";
                }
                $('#result').html(html);
            },
            error: function (err) {
                alert(err.statusText);
            }
        });
    }
});

$('.background-black').on('click', function () {
    $('.manage-image').css({ 'display': 'none', 'visibility': 'hidden' });
    $('.background-black').css({ 'display': 'none', 'visibility': 'hidden' });
});

$('.btn-chon-anh').on('click', function () {
    $('.manage-image').css({ 'display': 'block', 'visibility': 'visible' });
    $('.background-black').css({ 'display': 'block', 'visibility': 'visible' });
});