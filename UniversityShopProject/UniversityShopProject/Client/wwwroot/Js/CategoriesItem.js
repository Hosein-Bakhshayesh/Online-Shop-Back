var firstRangeValue = document.getElementById("Firstrangeval");
var lastRangeValue = document.getElementById("Lastrangeval");

var first;
var last = [0, 0, 0];
function FirstRangeChange() {
    first = firstRangeValue.innerText.toString();
    if (first.length > 6) {
        firstRangeValue.innerText = first.substring(0, first.length - 6) + ',' + first.substring(first.length - 6, first.length - 3) + ',' + first.substring(first.length - 3, first.length);
    }
    else if (first.length > 3) {
        firstRangeValue.innerText = first.substring(0, first.length - 3) + ',' + first.substring(first.length - 3, first.length)
    }
    else {
        firstRangeValue.innerText = first.substring(0, first.length)
    }
}

function LastRangeChange() {

    last = lastRangeValue.innerText.toString();
    if (last.length > 6) {
        lastRangeValue.innerText = last.substring(0, last.length - 6) + ',' + last.substring(last.length - 6, last.length - 3) + ',' + last.substring(last.length - 3, last.length);
    }
    else if (last.length > 3) {
        lastRangeValue.innerText = last.substring(0, last.length - 3) + ',' + last.substring(last.length - 3, last.length)
    }
    else {
        lastRangeValue.innerText = last.substring(0, last.length)
    }
}
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
var firstRangeValueSM = document.getElementById("FirstrangevalSM");
var lastRangeValueSM = document.getElementById("LastrangevalSM");

var firstSM;
var lastSM = [0, 0, 0];
function FirstRangeChangeSM() {
    firstSM = firstRangeValueSM.innerText.toString();
    if (firstSM.length > 6) {
        firstRangeValueSM.innerText = firstSM.substring(0, firstSM.length - 6) + ',' + firstSM.substring(firstSM.length - 6, firstSM.length - 3) + ',' + firstSM.substring(firstSM.length - 3, firstSM.length);
    }
    else if (firstSM.length > 3) {
        firstRangeValueSM.innerText = firstSM.substring(0, firstSM.length - 3) + ',' + firstSM.substring(firstSM.length - 3, firstSM.length)
    }
    else {
        firstRangeValueSM.innerText = firstSM.substring(0, firstSM.length)
    }
}

function LastRangeChangeSM() {

    lastSM = lastRangeValueSM.innerText.toString();
    if (lastSM.length > 6) {
        lastRangeValueSM.innerText = lastSM.substring(0, lastSM.length - 6) + ',' + lastSM.substring(lastSM.length - 6, lastSM.length - 3) + ',' + lastSM.substring(lastSM.length - 3, lastSM.length);
    }
    else if (lastSM.length > 3) {
        lastRangeValueSM.innerText = lastSM.substring(0, lastSM.length - 3) + ',' + lastSM.substring(lastSM.length - 3, lastSM.length)
    }
    else {
        lastRangeValueSM.innerText = lastSM.substring(0, lastSM.length)
    }
}