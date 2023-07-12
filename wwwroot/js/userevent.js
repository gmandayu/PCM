// User event handlers
ew.events = {
};

// Chart user configurations
ew.charts = {
};

// Global client script
ew.clientScript = function() {
    /**
     * Write your global client script here, no need to add script tags.
     * Note: JAVASCRIPT ONLY. DO NOT mix Razor Codes and JavaScript.
     */
     ew.selectOptions.minimumResultsForSearch=3;
};

// Global startup script
ew.startupScript = function() {
    /**
     * Write your global client script here, no need to add script tags.
     * Note: JAVASCRIPT ONLY. DO NOT mix Razor Codes and JavaScript.
     */
    // This code block will execute when the page has finished rendering
    $('table').addClass('table-head-fixed');

    // Select the div in header that contains table caption name only
    const $tableCaptionHeaderDiv = $('.content-header > .container-fluid > .row > .col-sm-6').first();

    // Select the div that contains breadcrumbs
    const $breadCrumbHeaderDiv = $('.content-header > .container-fluid > .row > .col-sm-6:eq(1)');

    // Resize the div that contains breadcrumbs
    $breadCrumbHeaderDiv.removeClass('col-sm-6').addClass('col-sm-12');

    // Delete the selected div
    $tableCaptionHeaderDiv.remove();

    // Target the ol element that has breadcrumb class
    const $breadCrumbOl = $('.breadcrumb').first();

    // change the breadcrumb position to left side
    $breadCrumbOl.removeClass('float-sm-end').addClass('float-sm-start');
    const selectedLanguage = ew.vars['languages']['languages'].filter(obj => obj.selected === true)[0];
    if (selectedLanguage.id === 'en-US') {
        ew.language.phrases['invaliduidpwd'] = "Incorrect email or password";
        ew.language.phrases['username'] = "Email";
        ew.language.phrases['enterusername'] = "Please enter email";
        ew.language.phrases['invalidusernamechars'] = "Email must not contain &, <, >, \", or '";
    } else if (selectedLanguage.id === 'id-ID') {
        ew.language.phrases['invaliduidpwd'] = "Email atau kata sandi tidak valid";
        ew.language.phrases['username'] = "Email";
        ew.language.phrases['enterusername'] = "Masukkan email Anda";
        ew.language.phrases['invalidusernamechars'] = "Email pengguna harus tidak boleh mengandung &, <, >, \", atau '";
    }
    const navbar = $('body div.wrapper.ew-layout nav.main-header');
    navbar.addClass('fixed-top');
    const navbarHeightWithPadding = navbar.outerHeight();
    // set height of content header to equivalent of the height of the navbar
    $('body div.wrapper.ew-layout div.content-wrapper').css('margin-top', navbarHeightWithPadding + 'px');

    // gmandayu: untuk tanda bintang
    const requiredMessage = (selectedLanguage.id === 'en-US') ? 'Required' : 'Wajib';
    document.documentElement.style.setProperty('--required-message', `"${requiredMessage}"`);

    // add chat support link
    const chatSupportLink = $('<a>')
        .attr('id', 'chat-support')
        .addClass('nav-link')
        .attr('href', `https://wa.me/+6281277770135`)
        .attr('target', '_blank')
        .attr('data-bs-toggle', 'tooltip')
        .attr('data-bs-placement', 'bottom')
        .attr('data-bs-title', (selectedLanguage.id === 'en-US') ? 'Chat Support' : 'Bantuan via Chat')
        .append($('<i>')
          .addClass('fa-brands fa-whatsapp ew-icon')
          .css('font-size', '1.25rem')
        );
    const chatSupportNavItem = $('<li>').addClass('nav-item').append(chatSupportLink);
    $('ul#ew-navbar-end').prepend(chatSupportNavItem);
    const chatSupportEl = document.getElementById('chat-support');
    const chatSupportTooltip = new bootstrap.Tooltip(chatSupportEl);
};