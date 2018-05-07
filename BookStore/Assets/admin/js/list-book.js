$(document).ready(function () {
    $('.title-book').click(function () {
        var id  = $(this).attr('id');
        $('#detail-book-' + id).toggle();
    });

    var homeconfig = {
        pageSize: 3,
        pageIndex: 1,
    }

    var bookController = {
        init: function () {
            bookController.registerEvent();
            bookController.loadData();
        },

        registerEvent: function () {
            $(document).on('click', '.btn-delete', function (e) {
                e.preventDefault();
                var id = $(this).data('id');
                if (confirm("Bạn có chắc xóa sách này không?")) {
                    bookController.deleteBook(id);
                }
            });
        },

        deleteBook: function (id) {
            $.ajax({
                url: '/Admin/Book/DeleteBook',
                data: {
                    id: id
                },
                type: 'POST',
                dataType: 'json',
                success: function (response) {
                    if (response.status == true) {
                        notify({
                            type: "success", //alert | success | error | warning | info
                            title: "Xóa sách thành công!",
                            position: {
                                x: "right", //right | left | center
                                y: "top" //top | bottom | center
                            },
                            size: "small",
                            autoHide: true
                        });
                        bookController.loadData();
                    }
                }
            });
        },

        loadData: function () {
            $.ajax({
                url: '/Admin/Book/loadData',
                type: "GET",
                data: {
                    page: homeconfig.pageIndex,
                    pageSize: homeconfig.pageSize
                },
                dataType: 'json',
                success: function (response) {
                    if (response.status == true) {
                        console.log(response.data);
                        var html = '';
                        var template = $('#data-template').html();
                        $.each(data, function (i, item) {
                            html += Mustache.render(template, {
                                ID: item.ID,
                                Name: item.Name,
                                Alias: item.Alias,
                                Price: item.Price,
                                Quanlity: item.Quanlity,
                                ViewCount: item.ViewCount,
                                Status: item.Status == true ? "<span class=\"badge badge-success\">ON</span>" : "<span class=\"badge badge-default\">OFF</span>",
                                Image: item.Image != null ? item.Image : "/Assets/admin/css/images/alter-image.jpg",
                                PublicationDate: item.PublicationDate,
                                BookCover: item.BookCover,
                                Author: item.Author,
                                Catalog: item.Catalog,
                                Category: item.Category,
                                Publisher: item.Publisher,
                            });
                        });
                        $('#resultBook').html(html);
                        bookController.paging(response.totalRow, function () {
                            bookController.loadData();
                        });
                    }
                }
            });
        },

        paging: function (totalRow, Callback) {
            var totalPage = Math.ceil(totalRow / homeconfig.pageSize);

            if ($('#pagination a').length === 0 || changePageSize === true) {
                $('#pagination').empty();
                $('#pagination').removeData("twbs-pagination");
                $('#pagination').unbind("page");
            }

            $('#pagination').twbsPagination({
                totalPages: totalPage,
                visiblePages: 7,
                first: "Đầu",
                next: "Tiếp",
                last: "Cuối",
                prev: "Trước",
                onPageClick: function (event, page) {
                    homeconfig.pageIndex = page;
                    setTimeout(Callback, 200);
                }
            });
        }
    }
    bookController.init();
});

