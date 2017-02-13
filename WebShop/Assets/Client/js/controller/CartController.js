var cart = {
    init:function()
    {
        cart.regEvents();
    },
    regEvents: function () {                                            
        $('#btnContinute').off('click').on('click', function () {       // Nút mua hàng tiếp
            window.location.href = "/";
        });

        $('#btnUpdate').off('click').on("click", function () {          // Nút cập nhật giỏ hàng
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/CartItem/Update',
                data: { CartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status==true)
                    {
                        window.location.href = "/gio-hang";
                    }
                }
            })

        });
        $('#btnDeleteAll').off('click').on("click", function () {          // Nút xóa giỏ hàng            
            $.ajax({
                url: '/CartItem/DeleteAll',               
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })

        });
        $('.btn-delete').off('click').on("click", function (e) {          // Nút xóa 1 item trong giỏ hàng            
            e.preventDefault();
            $.ajax({
                data: {id:$(this).data('id')},
                url: '/CartItem/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })

        });
        $('#btnPay').off('click').on('click', function () {       // Nút thanh toán
            window.location.href = "/thanh-toan";
        });
    }
}
cart.init();