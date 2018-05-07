$(document).ready(function() {
    $('.a-book.category').click(function (e) {
        var alias = $(this).attr('data-id')
        console.log('dât');
        $.ajax({
            url: '/sach-theo-the-loai',
            data: {
                alias: alias
            },
            type: 'POST',
            success: function (response) {
                var html = '';
                var data = response.data;
                $.each(data, function (i, item) { 
                    var html = '';
                    html += '<div class="book">';
                    html += '<div class="book-top">';
                    html += '<img src="' + item.Image + '" />';
                    html += '</div>';
                    html += '<div class="book-bot">';
                    html += '<a href="#" class="title-book">'+item.Name+'</a>';
                    html += '<a href="#" class="name-author">'+item.Authors+'</a>';
                    html += '<div class="price">';
                    html += '<span class="price-market">' + item.Price + ' đ</span>';
                    html += '<span class="price-promotion">' + item.Price + ' đ</span>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';

                    $('#list-book').html(html);
                })
            },
        })
    })
})