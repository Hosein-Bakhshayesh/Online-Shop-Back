////////////////////////////////////////////////////////////////////////

var showMoreTechnical = document.getElementById("show-more-technical");
var showMoreBtnTechnical = document.getElementById("show-more-technical-btn");

function showMoreFunction()
{
    if(showMoreTechnical.classList == 'd-none')
    {
        showMoreTechnical.className = 'd-block';
        showMoreBtnTechnical.innerText = '';
        showMoreBtnTechnical.innerText = 'مشاهده کمتر ...';
    }
    else if(showMoreTechnical.classList == 'd-block')
    {
        showMoreTechnical.className = 'd-none';
        showMoreBtnTechnical.innerText = '';
        showMoreBtnTechnical.innerText = 'مشاهده بیشتر ...';
    }
}

//////////////////////////////////////////////////////////////////////
var showMoreComments = document.getElementById("show-more-comments");
var showMoreCommentsBtn = document.getElementById("show-more-comments-btn");

function showMoreCommentsFunction()
{
    if(showMoreComments.classList == 'd-none')
    {
        showMoreComments.className = 'd-block';
        showMoreCommentsBtn.innerText = '';
        showMoreCommentsBtn.innerText = 'مشاهده نظرات کمتر ...';
    }
    else if(showMoreComments.classList == 'd-block')
    {
        showMoreComments.className = 'd-none';
        showMoreCommentsBtn.innerText = '';
        showMoreCommentsBtn.innerText = 'مشاهده نظرات بیشتر ...';
    }
}