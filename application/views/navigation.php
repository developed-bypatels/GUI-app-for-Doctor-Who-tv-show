    <!--[if lte IE 9]>
            <p class="browserupgrade">You are using an <strong>outdated</strong> browser. Please <a href="https://browsehappy.com/">upgrade your browser</a> to improve your experience and security.</p>
        <![endif]-->

    <!-- header-start -->
    <header>
        <div class="header-area ">
            <div id="sticky-header" class="main-header-area">
                <div class="container-fluid p-0">
                    <div class="row align-items-center no-gutters">
                        <div class="col-xl-2 col-lg-2">
                            <div class="logo-img">
                                <a href="index.html">
                                    <img src="<?= assetUrl(); ?>img/logo.png" alt="">
                                </a>
                            </div>
                        </div>
                        <div class="col-xl-7 col-lg-7">
                            <div class="main-menu  d-none d-lg-block">
                                <nav>
                                    <ul id="navigation">
                                        <li><a class="<?php if($isActive == 'home'){echo 'active';} else { echo '';} ?>" href="<?= base_url() ?>">home</a></li>
                                        <li><a class="<?php if($isActive == 'Courses'){echo 'active';} else { echo '';} ?>" href="<?= base_url() ?>index.php?/Courses">Courses</a></li>
                                        <li><a class="<?php if($isActive == 'pages'){echo 'active';} else { echo '';} ?>" href="#">pages <i class="ti-angle-down"></i></a>
                                        </li>
                                        <li><a class="<?php if($isActive == 'about'){echo 'active';} else { echo '';} ?>" href="<?= base_url() ?>index.php/About">About</a></li>
                                        <li><a class="<?php if($isActive == 'blog'){echo 'active';} else { echo '';} ?>" href="<?= base_url() ?>index.php?/Blog">Blog <i class="ti-angle-down"></i></a>
                                        </li>
                                        <li><a class="<?php if($isActive == 'contact'){echo 'active';} else { echo '';} ?>" href="<?= base_url() ?>index.php?/Contact">Contact</a></li>
                                    </ul>
                                </nav>
                            </div>
                        </div>
                        <div class="col-xl-3 col-lg-3 d-none d-lg-block">
                            <div class="log_chat_area d-flex align-items-center">
                                <a href="#test-form" class="login popup-with-form">
                                    <i class="flaticon-user"></i>
                                    <span>log in</span>
                                </a>
                                <div class="live_chat_btn">
                                    <a class="boxed_btn_orange" href="#">
                                        <i class="fa fa-phone"></i>
                                        <span>+10 378 467 3672</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="mobile_menu d-block d-lg-none"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </header>