
/*Document Load */
$(function () {

    //------MODALS------
    //Remove cached data in modal window
    $('body').on('hidden.bs.modal', '.modal', function () {

        $('.modal-content').empty();
        $(this).removeData('bs.modal');
    });

    //TODO: for correct client-validation in modal window
    $('body').on('shown.bs.modal', function () {
                /*var $form = $('form'); //modal - dialog


        $form.submit(function (e) {
            e.preventDefault();
            var form = $('.modal-dialog form');
            form.validate({
                rules: {
                    name: "required",
                    email: {
                        required: true,
                        email: true
                    },
                    phone: {
                        required: true,
                        phone: true
                    }
                },
                messages: {
                    name: "Please let us know who you are.",
                    email: "A valid email will help us get in touch with you.",
                    phone: "Please provide a valid phone number."
                }
            });
            if (!form.valid()) {
                return;
            }
            else {
                 $.ajax({
                     url: this.action,
                     type: this.method,
                     data: $(this).serialize(),
                     success: function (result) {
 
                         //if (result.success) {
                             $(form).modal('hide');
                             location.reload(); //Refresh
                         //} else {
                             //$('#myModalContent').html(result);
                             //bindForm();
                         //}
                     }
                 });
                 return false;
             };
        });*/
    });


    //2. Check type of board
    if ($('[name="dashboard"]').val() == "admin") {
        //------Init admin left-right menu bars------
        //if ($.Board && $.Board.hasOwnProperty("leftSideBar"))
        //    $.Board.leftSideBar.activate();
    }
    else {
        if ($.Board && $.Board.rightSideBar) {
            $.Board.rightSideBar.activate();

            //Shopping cart init (only on non-admin dashboard)

            //if (!cartNotInited)
            cart.init(); //NOTE: init data from user session cach !!!
        }
    }
});

if (typeof jQuery === "undefined") {
    throw new Error("jQuery plugins need to be before this file");
}

$.Board = {};
$.Board.options = {
    colors: {
        red: '#F44336',
        pink: '#E91E63',
        purple: '#9C27B0',
        deepPurple: '#673AB7',
        indigo: '#3F51B5',
        blue: '#2196F3',
        lightBlue: '#03A9F4',
        cyan: '#00BCD4',
        teal: '#009688',
        green: '#4CAF50',
        lightGreen: '#8BC34A',
        lime: '#CDDC39',
        yellow: '#ffe821',
        amber: '#FFC107',
        orange: '#FF9800',
        deepOrange: '#FF5722',
        brown: '#795548',
        grey: '#9E9E9E',
        blueGrey: '#607D8B',
        black: '#000000',
        white: '#ffffff'
    },
    leftSideBar: {
        scrollColor: 'rgba(0,0,0,0.5)',
        scrollWidth: '4px',
        scrollAlwaysVisible: false,
        scrollBorderRadius: '0',
        scrollRailBorderRadius: '0',
        scrollActiveItemWhenPageLoad: true,
        breakpointWidth: 1170
    },
    dropdownMenu: {
        effectIn: 'fadeIn',
        effectOut: 'fadeOut'
    }
}

/* Left Sidebar - Function   */
$.Board.leftSideBar = {
    activate: function () {
        var _this = this;
        var $body = $('body');
        var $overlay = $('.overlay');

        //Close sidebar
        $(window).click(function (e) {
            var $target = $(e.target);
            if (e.target.nodeName.toLowerCase() === 'i') { $target = $(e.target).parent(); }

            if (!$target.hasClass('bars') && _this.isOpen() && $target.parents('#leftsidebar').length === 0) {
                if (!$target.hasClass('js-right-sidebar'))
                    $overlay.fadeOut();
                $body.removeClass('overlay-open');
            }
        });

        $.each($('.menu-toggle.toggled'), function (i, val) {
            $(val).next().slideToggle(0);
        });

        //When page load
        $.each($('.menu .list li.active'), function (i, val) {
            var $activeAnchors = $(val).find('a:eq(0)');

            $activeAnchors.addClass('toggled');
            $activeAnchors.next().show();
        });

        //Collapse or Expand Menu
        $('.menu-toggle').on('click', function (e) {
            var $this = $(this);
            var $content = $this.next();

            if ($($this.parents('ul')[0]).hasClass('list')) {
                var $not = $(e.target).hasClass('menu-toggle') ? e.target : $(e.target).parents('.menu-toggle');

                $.each($('.menu-toggle.toggled').not($not).next(), function (i, val) {
                    if ($(val).is(':visible')) {
                        $(val).prev().toggleClass('toggled');
                        $(val).slideUp();
                    }
                });
            }

            $this.toggleClass('toggled');
            $content.slideToggle(320);
        });

        //Set menu height
        _this.setMenuHeight();
        _this.checkStatuForResize(true);
        $(window).resize(function () {
            _this.setMenuHeight();
            _this.checkStatuForResize(false);
        });

        //Set Waves
        // Waves.attach('.menu .list a', ['waves-block']);
        // Waves.init();
    },
    setMenuHeight: function (isFirstTime) {
        if (typeof $.fn.slimScroll != 'undefined') {
            var configs = $.Board.options.leftSideBar;
            var height = ($(window).height() - ($('.legal').outerHeight() + $('.user-info').outerHeight() + $('.navbar').innerHeight()));
            var $el = $('.list');

            $el.slimscroll({
                height: height + "px",
                color: configs.scrollColor,
                size: configs.scrollWidth,
                alwaysVisible: configs.scrollAlwaysVisible,
                borderRadius: configs.scrollBorderRadius,
                railBorderRadius: configs.scrollRailBorderRadius
            });

            //Scroll active menu item when page load, if option set = true
            //if ($.Board.options.leftSideBar.scrollActiveItemWhenPageLoad) {
            //     var activeItemOffsetTop = $('.menu .list li.active')[0].offsetTop;
            //    if (activeItemOffsetTop > 150) $el.slimscroll({ scrollTo: activeItemOffsetTop + 'px' });
            //}
        }
    },
    checkStatuForResize: function (firstTime) {
        var $body = $('body');
        var $openCloseBar = $('.navbar .navbar-header .bars');
        var width = $body.width();

        if (firstTime) {
            $body.find('.content, .sidebar').addClass('no-animate').delay(1000).queue(function () {
                $(this).removeClass('no-animate').dequeue();
            });
        }

        if (width < $.Board.options.leftSideBar.breakpointWidth) {
            $body.addClass('ls-closed');
            $openCloseBar.fadeIn();
        }
        else {
            $body.removeClass('ls-closed');
            $openCloseBar.fadeOut();
        }
    },
    isOpen: function () {
        return $('body').hasClass('overlay-open');
    }
};

/* Right Sidebar - Function   */
$.Board.rightSideBar = {
    activate: function () {
        var _this = this;
        var $sidebar = $('#rightsidebar');

        var $overlay = $('.overlay');

        $('.js-right-sidebar').on('click', function () {
            $sidebar.toggleClass('open');
            if (_this.isOpen()) {
                $overlay.fadeIn();
            }
            else {
                $overlay.fadeOut();
            }
        });
    },
    isOpen: function () {
        return $('.right-sidebar').hasClass('open');
    }
}

//$.Cart = {};
var cart = (function ($) {
    this.cartItems = [];
    var productsOffset = 3;
    var theme,
        onCart = false,
       
        totalPrice = 0;
    theme = $.jqx.theme;

    //var products = $.map('.draggable-demo-product', function () {
    //    var header = $(this).children(".draggable-demo-product-header");
    //    var name = $(header).text();//.children(".draggable-demo-product-header-label").val();
    //    var picture = $(this).children(".draggable-demo-product-price").val();
    //    var priceVal = $(this).find('.draggable-demo-product-price').text().replace('Price: $', ''); //$(this).children("img").attr('src');
    //    return name + ':' + { pic: picture, price: priceVal };
    //});
    //var products = {
    //    'Retro Rock T-shirt': {
    //        pic: 'black-retro-rock-band-guitar-controller.png',
    //        price: 15
    //    },
    //    'Lucky T-shirt': {
    //        pic: 'bright-green-gettin-lucky-in-kentucky.png',
    //        price: 18
    //    },
    //},

    /*render shopping cart */
    function gridRendering() {
        $("#jqxgrid").jqxGrid(
            {
                width: 280,//height: 335,
                columnsresize: true,
                enabletooltips: true,
                keyboardnavigation: false,
                selectionmode: 'none',
                pagesize: 10,
                pageable: true,
                columns: [
                    { text: 'Product', dataField: 'name', width: 150 },
                    { text: 'Count', dataField: 'count', width: 60 },
                    { text: 'Remove', dataField: 'remove', width: 60 }
                ]
            });
        $("#jqxgrid").on('cellclick', function (event) {
            var index = event.args.rowindex;
            if (event.args.datafield == 'remove') {
                var item = cartItems[index];
                if (item.count > 1) {
                    item.count -= 1;
                    updateGridRow(index, item);
                }
                else {
                    cartItems.splice(index, 1);
                    removeGridRow(index);
                }
                updatePrice(-item.price);
            }
        });
    };

    function addClasses() {
        $('.draggable-demo-catalog').addClass('jqx-scrollbar-state-normal-' + theme);
        $('.draggable-demo-title').addClass('jqx-expander-header-' + theme);
        $('.draggable-demo-title').addClass('jqx-expander-header-expanded-' + theme);
        $('.draggable-demo-total').addClass('jqx-expander-header-' + theme).addClass('jqx-expander-header-expanded-' + theme);
        if (theme === 'shinyblack') {
            $('.draggable-demo-shop').css('background-color', '#555');
            $('.draggable-demo-product').css('background-color', '#999');
        }
    };

    //TODO: Create product cell (if there exist some products to be displayed in the catalog)
    function productsRendering(products) {
        var catalog = $('#catalog'),
            imageContainer = $('</div>'),
            image, product, left = 0, top = 0, counter = 0;
        for (var name in products) {
            product = products[name];
            image = createProduct(name, product);
            image.appendTo(catalog);
            if (counter !== 0 && counter % 3 === 0) {
                top += 147; // image.outerHeight() + productsOffset;
                left = 0;
            }
            image.css({
                left: left,
                top: top
            });
            left += 127; // image.outerWidth() + productsOffset;
            counter += 1;
        }

        //$('.draggable-demo-product').jqxDragDrop({ dropTarget: $('#cart'), revert: true });
    };

    function createProduct(name, product) {
        return $('<div class="draggable-demo-product jqx-rc-all">' +
            '<div class="jqx-rc-t draggable-demo-product-header jqx-widget-header-' + theme + ' jqx-fill-state-normal-' + theme + '">' +
            '<div class="draggable-demo-product-header-label"> ' + name + '</div></div>' +
            '<div class="jqx-fill-state-normal-' + theme + ' draggable-demo-product-price">Price: <strong>$' + product.price + '</strong></div>' +
            '<img src="../../images/t-shirts/' + product.pic + '" alt='
            + name + '" class="jqx-rc-b" />' +
            '</div>');
    };

    function render() {

        //create\render shopping Cart grid
        gridRendering();

        var cachedCartItems = localStorage.getItem('shoppingBagData');

        //Load products that already exists
        if (cachedCartItems && cachedCartItems != "null") {
            //productsRendering(cachedCartItems); //create products items views (if they don't exists)
            this.cartItems = JSON.parse(cachedCartItems);
            //refresh cart with previously saved selected products for the user
            if (this.cartItems) {
                for (var i = 0; i < this.cartItems.length; i++) {
                    var item = this.cartItems[i];
                    if (item.name) {
                        renderItem(item); // NOTE: do not add an item, only render
                    }
                    //addGridRow(item);
                    //updatePrice(item.price);  //totalPrice = CalculatePrice(cartItems);
                }
            }
        }

        //Attach D&D handler to each product
        $('.draggable-demo-product').each(function (index, elem) {
            $(this).jqxDragDrop({ dropTarget: $('#cart'), revert: true });      //console.log(elem);
        });
    };

    //Simply render existing cart item (after redirect between pages)
    function renderItem(item) {
        //var index = getItemIndex(item.name);
        addGridRow(item);
        updatePrice(item.price);
    };
    //Add and render item, if D&D selected product
    function addItem(item) {
        var index = getItemIndex(item.name);
        if (index >= 0) {
            this.cartItems[index].count += 1;
            updateGridRow(index, this.cartItems[index]);
        } else {

            if (this.cartItems == null)
                this.cartItems = []; //init empty array

            var id = this.cartItems.length;
            item = {
                name: item.name.trim(),
                count: 1,
                price: item.price,
                index: id,
                remove: '<div style="text-align: left; cursor: pointer; width: 23px;"' + 'id="draggable-demo-row-' + id + '">X</div>'
            };
            this.cartItems.push(item);
            addGridRow(item);
        }
        updatePrice(item.price);
    };
    function updatePrice(price) {
        if (isNaN(price))
            alert('Wrong price: ' + price);
        if ((price) && (typeof totalPrice !== 'undefined'))
            totalPrice += price;
        else
            totalPrice = 0;

        $('#total').html('$ ' + totalPrice);
    };
    function addGridRow(row) {
        $("#jqxgrid").jqxGrid('addrow', null, row);
    };
    function updateGridRow(id, row) {
        var rowID = $("#jqxgrid").jqxGrid('getrowid', id);
        $("#jqxgrid").jqxGrid('updaterow', rowID, row);
    };
    function removeGridRow(id) {
        var rowID = $("#jqxgrid").jqxGrid('getrowid', id);
        $("#jqxgrid").jqxGrid('deleterow', rowID);
    };

    function clearGrid() {
        //Remove grid items
        $("#jqxgrid").jqxGrid('clear');

        localStorage.removeItem('shoppingBagData');//clear cach : localStorage.setItem('shoppingBagData', null); 

        this.cartItems = []; //null  
       
        //Render\update grid of selected products and zero price
        render();
        updatePrice(null); //totalPrice = 0;
    };

    function getItemIndex(name) {
        if (this.cartItems) {
            for (var i = 0; i < this.cartItems.length; i += 1) {
                if (cartItems[i].name.trim() === name.trim()) {
                    return i;
                }
            }
        }
        return -1;
    };
    function toArray(obj) {
        var item, array = [], counter = 1;
        for (var key in obj) {
            item = {};
            item = {
                name: key,
                price: obj[key].count,
                count: obj[key].price,
                number: counter
            }
            array.push(item);
            counter += 1;
        }
        return array;
    };

    function addEventListeners() {
        //$('#catalog').each('draggable-demo-product', function (index, elem) { })

        //attach D&D handler
        $('.draggable-demo-product').each(function (index, elem) {
            $(elem).mouseenter(function () {
                // $(elem).children('.draggable-demo-product-price').fadeTo(100, 0.9);
            });
            $(elem).mouseleave(function () {
                //$(elem).children('.draggable-demo-product-price').fadeTo(100, 0);
            });

            //Force attach events
            $(elem).on("mousedown", function () {
                $(this).trigger("dragStart");
            });

            $(elem).on('dragStart', function () {
                $('#cart').css('border', '2px solid #aaa');
                var that = this;

                var tshirt = $(elem).find('.draggable-demo-product-header').text(),
                    //TODO: replace currency
                    price = $(elem).find('.draggable-demo-product-price').text().replace('Price: $', '');
                price = parseInt(price, 10);

                $(this).jqxDragDrop('data', {
                    price: price,
                    name: tshirt
                });
            });

            $(elem).on('dragEnd', function (event) {
                $('#cart').css('border', '2px dashed #aaa');
                if (onCart) {
                    addItem({ price: event.args.price, name: event.args.name });
                    onCart = false;

                    //set\update Cart storage
                    var cartItemsJSON = JSON.stringify(cartItems);
                    localStorage.setItem('shoppingBagData', cartItemsJSON);
                    if ($("#cartItemsJson"))
                        $("#cartItemsJson").val(cartItemsJSON); //save to pass into controller
                }
            });

            $("#cart").on("mouseup", function (event) {
                var that = elem;

                $(that).trigger("dropTargetEnter");
            });

            $(elem).on('dropTargetEnter', function (event) {
                //TODO: check if elem on #cart;
                //if (event.target) {
                onCart = true;
                $(event.target).css('border', '2px solid #000');
                //    $(elem).jqxDragDrop('dropAction', 'none');
                //}
            });

            $(elem).on('dropTargetLeave', function (event) {
                $(event.args.target).css('border', '2px solid #aaa');
                onCart = false;
                $(elem).jqxDragDrop('dropAction', 'default');
            });
        });

        //attach clear selected products for shopping
        $('.clear-shopping-cart').unbind('click');
        $('.clear-shopping-cart').on('click', function () {

            clearGrid();
        });
    };

    //this.init = function () {
    //    //theme = getDemoTheme();
    //    render(false);
    //    addEventListeners();
    //    addClasses();
    //};

    function init() {

        //var isCartCached = localStorage.getItem("userCartCreated");

        //theme = getDemoTheme();

        render();
        addEventListeners();
        addClasses();

        //localStorage.setItem('userCartCreated', 1);
    };

    return { init: init }

})(jQuery);
