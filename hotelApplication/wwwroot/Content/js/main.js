function openForm() {
    document.getElementById("myForm").style.display = "block";
}

function closeForm() {
    document.getElementById("myForm").style.display = "none";
}
$(window).scroll(function(){
    $('.site-section').each(function(){
        var imagePos=$(this).offset().top;

        var topofWindow = $(window).scrollTop();
        if (imagePos < topofWindow + 650) {
            $(this).addClass("fadeInRight")
            
        }
    });
    $('.card-deck').each(function(){
        var imagePos=$(this).offset().top;

        var topofWindow = $(window).scrollTop();
        if (imagePos < topofWindow + 650) {
            $(this).addClass("fadeInLeft")
            
        }
    });
    $('.card-deck1').each(function(){
        var imagePos=$(this).offset().top;

        var topofWindow = $(window).scrollTop();
        if (imagePos < topofWindow + 650) {
            $(this).addClass("fadeInRight")
            
        }
    });
    $('.services').each(function(){
        var imagePos=$(this).offset().top;

        var topofWindow = $(window).scrollTop();
        if (imagePos < topofWindow + 650) {
            $(this).addClass("fadeInUp")
            
        }
    });
    $('.interactive').each(function(){
        var imagePos=$(this).offset().top;

        var topofWindow = $(window).scrollTop();
        if (imagePos < topofWindow + 650) {
            $(this).addClass("fadeInUp")
            
        }
    });
    $('.Navigate').each(function(){
        var imagePos=$(this).offset().top;

        var topofWindow = $(window).scrollTop();
        if (imagePos < topofWindow + 650) {
            $(this).addClass("fadeInUp")
            
        }
    });
    $('.site-section1').each(function(){
        var imagePos=$(this).offset().top;

        var topofWindow = $(window).scrollTop();
        if (imagePos < topofWindow + 650) {
            $(this).addClass("fadeInUp")
            
        }
    });
});