CheckBasketCount();

$(".add-basket-btn").click(function () {
    var id = $(this).data('id')
    var basketCount = $('#basketCount')
    var basketCurrentCount = $('#basketCount').html()
    $.ajax({
        method: "POST",
        url: "https://localhost:44338/basket/add",
        data: {
            id: id
        },
        success: function (result) {
            basketCurrentCount++;
            basketCount.html("")
            basketCount.append(basketCurrentCount)
            CheckBasketCount();
        }
    })
});


$(".wish-delete").click(function () {
    var id = $(this).data("id")

    $.ajax({
        method: "POST",
        url: "favourite/delete",
        data: {
            id: id
        },
        success: function (result) {
            $(`.wish-item[id=${id}]`).remove()
        }
    })
})









function CheckBasketCount() {
    var basketCountContainer = $("#basket-count")
    var basketCount = $("#basketCount").html()
    if (basketCount > 0) {
        $(basketCountContainer).removeClass("d-none")
    }
    else {
        $(basketCountContainer).addClass("d-none")
    }
}

function AddToBasket(id) {
    var basketCount = $('#basketCount')
    var basketCurrentCount = $('#basketCount').html()

    $.ajax({
        method: "POST",
        url: "https://localhost:44338/basket/add",
        data: {
            id: id
        },
        success: function (result) {
            basketCurrentCount++;
            basketCount.html("")
            $(`.add-basket-btn[data-id=${id}]`).addClass("added-basket")
            basketCount.append(basketCurrentCount)
            CheckBasketCount();
        }
    })
};


$("html").css("overflow", "auto")
$(document).on("click", "#basket", function () {
    $.ajax({
        method: "GET",
        url: "/basket/minibasket",
        success: function (result) {
            $('#cartItemList').html("");
            $('#cartItemList').append(result);
        }
    })
})

$(document).on("click", '.basket-delete', function () {
    var id = $(this).data('id')
    var basketCountContainer = $("#basket-count")
    var basketCount = $('#basketCount')
    var basketCurrentCount = $('#basketCount').html()
    var quantity = $(this).data('quantity')
    var count = $(`#form-${id}`).val()
    var sum = basketCurrentCount - quantity
    var itemTotalCount = $('#item-count')
    var price = $(this).data('price')
    var sumPrice = $('#sum-price').html()
    var sumPriceLast = $('#sum-price')

    $.ajax({
        method: "POST",
        url: "/basket/delete",
        data: {
            id: id
        },
        success: function (result) {
            if (sum == 0) {
                basketCountContainer.hide()
            }
            $(`.basket-products[id=${id}]`).remove();
            basketCount.html("")
            itemTotalCount.html("")
            itemTotalCount.append(sum + " items")
            basketCount.append(sum)
            sumPriceLast.html("")
            sumPriceLast.append(sumPrice - price * count)
        }
    })
})



$(document).on("click", '.decrease', function () {
    var id = $(this).data('id')
    var basketCount = $('#basketCount')
    var basketCurrentCount = $('#basketCount').html()
    var price = $(this).data('price')
    var itemTotalCount = $('#item-count')
    var total = $(`#total-price-${id}`)
    var count = $(`#form-${id}`).val()
    var sumPrice = $('#sum-price').html()
    var sumPriceLast = $('#sum-price')
    var sum = count * price

    sumPrice = parseFloat(sumPrice)
    $(".loader-2").show();
    $(".card-container").css("filter", "blur(1px)")
    $.ajax({
        method: "POST",
        url: "/basket/decreasecount",
        data: {
            id: id
        },
        success: function (result) {
            basketCurrentCount--;
            if (basketCurrentCount >= 1) {
                basketCount.html("")
                itemTotalCount.html("")
                itemTotalCount.append(basketCurrentCount + " items")
                basketCount.append(basketCurrentCount)
            }
            if (sum > 0) {
                total.html('')
                total.append(sum + "$")
                sumPriceLast.html("")
                sumPriceLast.append(sumPrice - price)
            }
        }
    })
})


$(document).on("click", '.increase', function () {
    var id = $(this).data('id')
    var basketCount = $('#basketCount')
    var price = $(this).data('price')
    price = parseInt(price)
    var itemTotalCount = $('#item-count')
    var total = $(`#total-price-${id}`)
    var count = $(`#form-${id}`).val()
    var sum = count * price
    var basketCurrentCount = $('#basketCount').html()
    var sumPrice = $('#sum-price').html()
    var sumPriceLast = $('#sum-price')
    sumPrice = parseFloat(sumPrice)
    $.ajax({
        method: "POST",
        url: "/basket/increasecount",
        data: {
            id: id
        },
        success: function (result) {
            basketCurrentCount++;
            basketCount.html("")
            sumPriceLast.html('')
            itemTotalCount.html("")
            total.html('')
            basketCount.append(basketCurrentCount)
            sumPriceLast.append(sumPrice + price)
            itemTotalCount.append(basketCurrentCount + " items")
            total.append(sum + "$")
        }
    })
})

// Basket end //




// Wish List  Start 

$(document).on('click', '.product-heart', function () {
    var id = $(this).data('id');
    $.ajax({
        method: "POST",
        url: "https://localhost:44338/favourite/add",
        data: {
            id: id
        },
        success: function (result) {
            $(`.product-heart[data-id=${id}]`).addClass("added-basket")

        }
    })
})


