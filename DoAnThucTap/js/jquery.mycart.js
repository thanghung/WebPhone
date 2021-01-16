﻿/*
 * jQuery myCart - v1.7 - 2018-03-07
 * http://asraf-uddin-ahmed.github.io/
 * Copyright (c) 2017 Asraf Uddin Ahmed; Licensed None
 */

(function ($) {
    "use strict";

    var OptionManager = (function () {
        var objToReturn = {};

        var _options = null;
        var DEFAULT_OPTIONS = {
            currencySymbol: ' VNĐ',
            classCartIcon: 'my-cart-icon',
            classCartBadge: 'my-cart-badge',
            classProductQuantity: 'my-product-quantity',
            classProductRemove: 'my-product-remove',
            classCheckoutCart: 'my-cart-checkout',
            affixCartIcon: true,
            showCheckoutModal: true,
            numberOfDecimals: 0,
            cartItems: null,
            clickOnAddToCart: function ($addTocart) { },
            afterAddOnCart: function (products, totalPrice, totalQuantity) { },
            clickOnCartIcon: function ($cartIcon, products, totalPrice, totalQuantity) { },
            checkoutCart: function (products, totalPrice, totalQuantity) {
                return false;
            },
        };


        var loadOptions = function (customOptions) {
            _options = $.extend({}, DEFAULT_OPTIONS);
            if (typeof customOptions === 'object') {
                $.extend(_options, customOptions);
            }
        };
        var getOptions = function () {
            return _options;
        };

        objToReturn.loadOptions = loadOptions;
        objToReturn.getOptions = getOptions;
        return objToReturn;
    }());

    var MathHelper = (function () {
        var objToReturn = {};
        var getRoundedNumber = function (number) {
            if (isNaN(number)) {
                throw new Error('Parameter is not a Number');
            }

            number = number * 1;
            var options = OptionManager.getOptions();
            return number.toFixed(options.numberOfDecimals);
        };
        objToReturn.getRoundedNumber = getRoundedNumber;
        return objToReturn;
    }());

    var ProductManager = (function () {
        var objToReturn = {};

        /*
        PRIVATE
        */
        localStorage.products = localStorage.products ? localStorage.products : "";
        var getIndexOfProduct = function (id) {
            var productIndex = -1;
            var products = getAllProducts();
            $.each(products, function (index, value) {
                if (value.id == id) {
                    productIndex = index;
                    return;
                }
            });
            return productIndex;
        };
        var setAllProducts = function (products) {
            localStorage.products = JSON.stringify(products);
        };
        var addProduct = function (id, name, summary, price, quantity, image) {
            var products = getAllProducts();
            products.push({
                id: id,
                name: name,
                summary: summary,
                price: price,
                quantity: quantity,
                image: image
            });
            setAllProducts(products);
        };

        /*
        PUBLIC
        */
        var getAllProducts = function () {
            try {
                var products = JSON.parse(localStorage.products);
                return products;
            } catch (e) {
                return [];
            }
        };
        var updatePoduct = function (id, quantity) {
            var productIndex = getIndexOfProduct(id);
            if (productIndex < 0) {
                return false;
            }
            var products = getAllProducts();
            products[productIndex].quantity = typeof quantity === "undefined" ? products[productIndex].quantity * 1 + 1 : quantity;
            setAllProducts(products);
            return true;
        };
        var setProduct = function (id, name, summary, price, quantity, image) {
            if (typeof id === "undefined") {
                console.error("id required");
                return false;
            }
            if (typeof name === "undefined") {
                console.error("name required");
                return false;
            }
            if (typeof image === "undefined") {
                console.error("image required");
                return false;
            }
            if (!$.isNumeric(price)) {
                console.error("price is not a number");
                return false;
            }
            if (!$.isNumeric(quantity)) {
                console.error("quantity is not a number");
                return false;
            }
            summary = typeof summary === "undefined" ? "" : summary;

            if (!updatePoduct(id)) {
                addProduct(id, name, summary, price, quantity, image);
            }
        };
        var clearProduct = function () {
            setAllProducts([]);
        };
        var removeProduct = function (id) {
            var products = getAllProducts();
            products = $.grep(products, function (value, index) {
                return value.id != id;
            });
            setAllProducts(products);
        };
        var getTotalQuantity = function () {
            var total = 0;
            var products = getAllProducts();
            $.each(products, function (index, value) {
                total += value.quantity * 1;
            });
            return total;
        };
        var getTotalPrice = function () {
            var products = getAllProducts();
            var total = 0;
            $.each(products, function (index, value) {
                total += value.quantity * value.price;
                total = MathHelper.getRoundedNumber(total) * 1;
            });
            return total;
        };

        objToReturn.getAllProducts = getAllProducts;
        objToReturn.updatePoduct = updatePoduct;
        objToReturn.setProduct = setProduct;
        objToReturn.clearProduct = clearProduct;
        objToReturn.removeProduct = removeProduct;
        objToReturn.getTotalQuantity = getTotalQuantity;
        objToReturn.getTotalPrice = getTotalPrice;
        return objToReturn;
    }());


    var loadMyCartEvent = function (targetSelector) {

        var options = OptionManager.getOptions();
        var $cartIcon = $("." + options.classCartIcon);
        var $cartBadge = $("." + options.classCartBadge);
        var classProductQuantity = options.classProductQuantity;
        var classProductRemove = options.classProductRemove;
        var classCheckoutCart = options.classCheckoutCart;

        var idCartModal = 'my-cart-modal';
        var idCartTable = 'my-cart-table';
        var idGrandTotal = 'my-cart-grand-total';
        var idEmptyCartMessage = 'my-cart-empty-message';
        var classProductTotal = 'my-product-total';
        var classAffixMyCartIcon = 'my-cart-icon-affix';


        if (options.cartItems && options.cartItems.constructor === Array) {
            ProductManager.clearProduct();
            $.each(options.cartItems, function () {
                ProductManager.setProduct(this.id, this.name, this.summary, this.price, this.quantity, this.image);
            });
        }

        $cartBadge.text(ProductManager.getTotalQuantity());

        if (!$("#" + idCartModal).length) {
            $('body').append(
                '<div class="modal fade" id="' + idCartModal + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">' +
                '<div class="modal-dialog" role="document">' +
                '<div class="modal-content">' +
                '<div class="modal-header">' +
                '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                '<h4 class="modal-title" id="myModalLabel"><span class="glyphicon glyphicon-shopping-cart"></span> Giỏ Hàng</h4>' +
                '</div>' +
                '<div class="modal-body">' +
                '<table class="table table-hover table-responsive" id="' + idCartTable + '"></table>' +
                '</div>' +
                '<div class="modal-footer">' +
                '<button><a href="/ThanhToan" style="text-decoration: none;">Thanh toán</a></button>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>'
            );
        }

        var drawTable = function () {
            var $cartTable = $("#" + idCartTable);
            $cartTable.empty();

            var products = ProductManager.getAllProducts();
            $.each(products, function () {
                var total = this.quantity * this.price;
                $cartTable.append(
                    '<tr title="' + this.summary + '" data-id="' + this.id + '" data-price="' + this.price + '">' +
                    '<td class="text-center" style="width: 30px;"><img width="30px" height="30px" src="' + this.image + '"/></td>' +
                    '<td>' + this.name + '</td>' +
                    '<td title="Đơn giá" class="text-right">' + MathHelper.getRoundedNumber(this.price).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + options.currencySymbol + '</td>' +
                    '<td title="Số Lượng"><input type="number" min="1" style="width: 70px;" class="' + classProductQuantity + '" value="' + this.quantity + '"/></td>' +
                    '<td title="Tổng Tiền" class="text-right ' + classProductTotal + '">' + MathHelper.getRoundedNumber(total).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + options.currencySymbol + '</td>' +
                    '<td title="Xóa giỏ hàng" class="text-center" style="width: 30px;"><a href="javascript:void(0);" class="btn btn-xs btn-danger ' + classProductRemove + '">X</a></td>' +
                    '</tr>'
                );
            });

            $cartTable.append(products.length ?
                '<tr>' +
                '<td></td>' +
                '<td><strong>Tổng Tiền</strong></td>' +
                '<td></td>' +
                '<td></td>' +
                '<td class="text-right"><strong id="' + idGrandTotal.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + '"></strong></td>' +
                '<td></td>' +
                '</tr>' :
                '<div class="alert alert-danger" role="alert" id="' + idEmptyCartMessage + '">Giỏ Hàng chưa có sản phẩm</div>'
            );


            showGrandTotal();
            writeCookie("Amount", MathHelper.getRoundedNumber(ProductManager.getTotalPrice()).toString(), 1);
            CheckCookie();
        };
        var showModal = function () {
            drawTable();
            $("#" + idCartModal).modal('show');
        };
        var updateCart = function () {
            $.each($("." + classProductQuantity), function () {
                var id = $(this).closest("tr").data("id");
                ProductManager.updatePoduct(id, $(this).val().toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            });
        };
        var showGrandTotal = function () {
            $("#" + idGrandTotal).text(MathHelper.getRoundedNumber(ProductManager.getTotalPrice()).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + options.currencySymbol);
        };

        //cookie
        function writeCookie(name, value, days) {
            var date, expires;
            if (days) {
                date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                expires = "; expires=" + date.toGMTString();
            } else {
                expires = "";
            }
            document.cookie = name + "=" + value + expires + "; path=/";
        }

        function getCookie(cname) {
            var name = cname + "=";
            var decodedCookie = decodeURIComponent(document.cookie);
            var ca = decodedCookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') {
                    c = c.substring(1);
                }
                if (c.indexOf(name) == 0) {
                    return c.substring(name.length, c.length);
                }
            }
            return "";
        }

        function checkCookie() {
            var user = getCookie("Amount");

            if (user == "0" || user == "0") {
                ProductManager.clearProduct();
                $cartBadge.text(ProductManager.getTotalQuantity());
            }

            console.log(user);
        }

        /*
        EVENT
        */
        if (options.affixCartIcon) {
            var cartIconBottom = $cartIcon.offset().top * 1 + $cartIcon.css("height").match(/\d+/) * 1;
            var cartIconPosition = $cartIcon.css('position');
            $(window).scroll(function () {
                $(window).scrollTop() >= cartIconBottom ? $cartIcon.addClass(classAffixMyCartIcon) : $cartIcon.removeClass(classAffixMyCartIcon);
            });
        }

        $cartIcon.click(function () {
            options.showCheckoutModal ? showModal() : options.clickOnCartIcon($cartIcon, ProductManager.getAllProducts(), ProductManager.getTotalPrice().toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","), ProductManager.getTotalQuantity());
        });

        $(document).on("input", "." + classProductQuantity, function () {
            var price = $(this).closest("tr").data("price");
            var id = $(this).closest("tr").data("id");
            var quantity = $(this).val();

            $(this).parent("td").next("." + classProductTotal).text(MathHelper.getRoundedNumber(price * quantity).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + options.currencySymbol);
            ProductManager.updatePoduct(id, quantity);

            $cartBadge.text(ProductManager.getTotalQuantity());
            showGrandTotal();
            writeCookie("Amount", MathHelper.getRoundedNumber(ProductManager.getTotalPrice()).toString(), 1);
            CheckCookie();
        });

        $(document).on('keypress', "." + classProductQuantity, function (evt) {
            if (evt.keyCode == 38 || evt.keyCode == 40) {
                return;
            }
            evt.preventDefault();
        });

        $(document).on('click', "." + classProductRemove, function () {
            var $tr = $(this).closest("tr");
            var id = $tr.data("id");
            $tr.hide(500, function () {
                ProductManager.removeProduct(id);
                drawTable();
                $cartBadge.text(ProductManager.getTotalQuantity());
            });
        });

        // Checkout
        $(document).on('click', "." + classCheckoutCart, function () {
            $("#" + idCartModal).modal("hide");
        });

        $(document).on('click', targetSelector, function () {
            var $target = $(this);
            options.clickOnAddToCart($target);

            var id = $target.data('id');
            var name = $target.data('name');
            var summary = $target.data('summary');
            var price = $target.data('price');
            var quantity = $target.data('quantity');
            var image = $target.data('image');

            ProductManager.setProduct(id, name, summary, price, quantity, image);
            $cartBadge.text(ProductManager.getTotalQuantity());

            options.afterAddOnCart(ProductManager.getAllProducts(), ProductManager.getTotalPrice().toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","), ProductManager.getTotalQuantity());
        });

        $(document).ready(function () {
            checkCookie();
        });
    };


    $.fn.myCart = function (userOptions) {
        OptionManager.loadOptions(userOptions);
        loadMyCartEvent(this.selector);
        return this;
    };
    //data-toggle="modal" data-target="#myModal 
})(jQuery);