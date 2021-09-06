function ibg(){

let ibg=document.querySelectorAll(".ibg");
for (var i = 0; i < ibg.length; i++) {
	if(ibg[i].querySelector('img')){
		ibg[i].style.backgroundImage = 'url('+ibg[i].querySelector('img').getAttribute('src')+')';
	}
}
}

ibg();


$(function (){
   $('.header-menu__icon').click(function(){
   	  $('.header__nav').toggleClass('active')
   	  $('.header-menu__icon').toggleClass('active')
   	  $('body').toggleClass('fixed')
   })
});

 $(function (){
     $(".body__side-title").click(function(event) {
         $(this).toggleClass('active');
         $(".body__side-element-box").slideToggle(300);
    });
});

$(function (){
     $(".body__tags-title").click(function(event) {
         $(this).toggleClass('active');
         $(".body__tags-box").slideToggle(300);
    });
});


/*  TABS
const tabsCon = document.querySelectorAll(".tabs__content");
const tabsBtn = document.querySelectorAll(".tabs__button-item");
tabsBtn.forEach(function(item) {
    item.addEventListener("click",function(){
      let crrBtn = item;
      let tabID = crrBtn.getAttribute("data-tab");
      let crrTab = document.querySelector(tabID);
      tabsBtn.forEach(function(item){
          item.classList.remove("active");
      });
       tabsCon.forEach(function(item){
          item.classList.remove("active");
      });
      crrBtn.classList.add("active");
      crrTab.classList.add("active");

    });
});
*/