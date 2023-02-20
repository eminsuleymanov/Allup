$(document).ready(function () {
    $('#searchInput').keyup(function () {

        let search = $(this).val();
        let category = $('#category').find(":selected").val();

        console.log(search + '' + category)
        if (search.length >= 3) {
            fetch('product/search?search=' + search + '&categoryId=' + category)
                .then(res => {
                    return res.text()
                }).then(data => {
                    $('#searchbody').html(data)
                })

        }
        else {
            $('#searchbody').html('')
        }
    })

    
    

    

    $(".productModal").click(function (e) {
        e.preventDefault();
        let url = $(this).attr('href');
        fetch(url).then(res => {
            return res.text();
        })

            .then(data => {
                $(".modal-content").html(data);

                $('.quick-view-image').slick({
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                    dots: false,
                    fade: true,
                    asNavFor: '.quick-view-thumb',
                    speed: 400,
                });

                $('.quick-view-thumb').slick({
                    slidesToShow: 4,
                    slidesToScroll: 1,
                    asNavFor: '.quick-view-image',
                    dots: false,
                    arrows: false,
                    focusOnSelect: true,
                    speed: 400,
                });
            })
    })
    
})
