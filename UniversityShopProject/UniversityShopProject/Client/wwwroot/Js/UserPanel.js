var buttonActive = document.getElementById("button-active");
var userPanel = document.getElementById("userInfoPanel");
var wishList = document.getElementById("wishListPanel");
var orderList = document.getElementById("orderList");
var locationList = document.getElementById("locationLists");

function openUserPanel()
{
    buttonActive.style.top = "0px";
    userPanel.style.display = "block";
    wishList.style.display = "none"
    orderList.style.display = "none"
    locationList.style.display = "none"
}

function openWishPanel()
{
    buttonActive.style.top = "60px";
    userPanel.style.display = "none";
    wishList.style.display = "block"
    orderList.style.display = "none"
    locationList.style.display = "none"
}

function openOrderPanel()
{
    buttonActive.style.top = "120px";
    userPanel.style.display = "none";
    wishList.style.display = "none"
    orderList.style.display = "block"
    locationList.style.display = "none"
}

function openLocationPanel()
{
    buttonActive.style.top = "180px";
    userPanel.style.display = "none";
    wishList.style.display = "none"
    orderList.style.display = "none "
    locationList.style.display = "block"
}