import { Component, OnInit, AfterViewInit, AfterViewChecked, AfterContentInit } from '@angular/core';
import { ROUTES } from './sidebar-routes.config';
import { Router } from '@angular/router';

declare var $: any;
let sidebarTimer;

@Component({
    moduleId: module.id,
    // tslint:disable-next-line:component-selector
    selector: 'sidebar-cmp',
    templateUrl: './sidebar.component.html',
})

export class SidebarComponent implements OnInit {
    public menuItems: any[];
    sass= sessionStorage.getItem('User');
    constructor(private _router: Router) { }
    isNotMobileMenu() {
        if ($(window).width() > 991) {
            return false;
        }
        return true;
    }

    ngOnInit() {
        let isWindows = navigator.platform.indexOf('Win') > -1 ? true : false;
        if (isWindows) {
           // if we are on windows OS we activate the perfectScrollbar function
            const $sidebar = $('.sidebar-wrapper');
            $sidebar.perfectScrollbar();
        }
        this.menuItems = ROUTES.filter(menuItem => menuItem);
        isWindows = navigator.platform.indexOf('Win') > -1 ? true : false;

        if (isWindows) {
           // if we are on windows OS we activate the perfectScrollbar function
           $('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar();
           $('html').addClass('perfect-scrollbar-on');
       } else {
           $('html').addClass('perfect-scrollbar-off');
       }
    }

    // tslint:disable-next-line:use-life-cycle-interface
    ngAfterViewInit() {
        // init Moving Tab after the view is initialisez
        setTimeout(() => {
            // tslint:disable-next-line:no-use-before-declare
            if (mda.movingTabInitialised === false) {
                // tslint:disable-next-line:no-use-before-declare
                mda.initMovingTab();
                // tslint:disable-next-line:no-use-before-declare
                mda.movingTabInitialised = true;
            }
        }, 10);
    }
    logout() {
        sessionStorage.removeItem('User');
        this._router.navigate(['/pages/login']);
    }
}

// The Moving Tab (the element that is moving on the sidebar, when you switch the pages) is depended on
// jQuery because it is doing a lot of calculations and changes based on Bootstrap collapse elements.
// If you have a better suggestion please send it to hello@creative-tim.com and we would be glad to talk more about this improvement.
// Thank you!

const mda: any = {
    movingTab: '<div class="sidebar-moving-tab"/>',
    isChild: false,
    sidebarMenuActive: '',
    movingTabInitialised: false,
    distance: 0,

    setMovingTabPosition: function($currentActive){
       $currentActive = mda.sidebarMenuActive;
       mda.distance = $currentActive.parent().position().top - 10;

       if ($currentActive.closest('.collapse').length !== 0) {
           const parent_distance = $currentActive.closest('.collapse').parent().position().top;
           mda.distance = mda.distance + parent_distance;
       }

       mda.moveTab();
    },
    initMovingTab: function(){
       mda.movingTab = $(mda.movingTab);

       mda.sidebarMenuActive = $('.sidebar .nav-container > .nav > li.active > a:not([data-toggle="collapse"]');

       if (mda.sidebarMenuActive.length !== 0) {
           mda.setMovingTabPosition(mda.sidebarMenuActive);
       } else {
           mda.sidebarMenuActive = $('.sidebar .nav-container .nav > li.active .collapse li.active > a');
           mda.isChild = true;
           this.setParentCollapse();
       }
       mda.sidebarMenuActive.parent().addClass('visible');

       const button_text = mda.sidebarMenuActive.html();
       mda.movingTab.html(button_text);

       $('.sidebar .nav-container').append(mda.movingTab);

       if (window.history && window.history.pushState) {
           $(window).on('popstate', function() {

               setTimeout(function(){
                   mda.sidebarMenuActive = $('.sidebar .nav-container .nav li.active a:not([data-toggle="collapse"])');

                   if (mda.isChild === true) {
                       this.setParentCollapse();
                   }
                   clearTimeout(sidebarTimer);

                   const $currentActive = mda.sidebarMenuActive;

                   $('.sidebar .nav-container .nav li').removeClass('visible');

                   const $movingTab = mda.movingTab;
                   $movingTab.addClass('moving');

                   $movingTab.css('padding-left', $currentActive.css('padding-left'));
                   // tslint:disable-next-line:no-shadowed-variable
                   const button_text = $currentActive.html();

                   mda.setMovingTabPosition($currentActive);

                   sidebarTimer = setTimeout(function(){
                       $movingTab.removeClass('moving');
                       $currentActive.parent().addClass('visible');
                   }, 650);

                   setTimeout(function(){
                       $movingTab.html(button_text);
                   }, 10);
               }, 10);

           });
       }

       $('.sidebar .nav .collapse').on('hidden.bs.collapse', function () {
           const $currentActive = mda.sidebarMenuActive;

           mda.distance = $currentActive.parent().position().top - 10;

           if ($currentActive.closest('.collapse').length !== 0) {
               const parent_distance = $currentActive.closest('.collapse').parent().position().top;
               mda.distance = mda.distance + parent_distance;
           }

           mda.moveTab();
       });

       $('.sidebar .nav .collapse').on('shown.bs.collapse', function () {
           const $currentActive = mda.sidebarMenuActive;

           mda.distance = $currentActive.parent().position().top - 10;

           if ($currentActive.closest('.collapse').length !== 0) {
               const parent_distance = $currentActive.closest('.collapse').parent().position().top;
               mda.distance = mda.distance + parent_distance;
           }

           mda.moveTab();
       });

       $('.sidebar .nav-container .nav > li > a:not([data-toggle="collapse"])').click(function(){
           mda.sidebarMenuActive = $(this);
           const $parent = $(this).parent();

           if (mda.sidebarMenuActive.closest('.collapse').length === 0) {
               mda.isChild = false;
           }

           // we call the animation of the moving tab
           clearTimeout(sidebarTimer);

           let $currentActive = mda.sidebarMenuActive;

           $('.sidebar .nav-container .nav li').removeClass('visible');

           const $movingTab = mda.movingTab;
           $movingTab.addClass('moving');

           $movingTab.css('padding-left', $currentActive.css('padding-left'));
           // tslint:disable-next-line:no-shadowed-variable
           const button_text = $currentActive.html();

           $currentActive = mda.sidebarMenuActive;
           mda.distance = $currentActive.parent().position().top - 10;

           if ($currentActive.closest('.collapse').length !== 0) {
               const parent_distance = $currentActive.closest('.collapse').parent().position().top;
               mda.distance = mda.distance + parent_distance;
           }

           mda.moveTab();

           sidebarTimer = setTimeout(function(){
               $movingTab.removeClass('moving');
               $currentActive.parent().addClass('visible');
           }, 650);

           setTimeout(function(){
               $movingTab.html(button_text);
           }, 10);
       });
    },
    setParentCollapse: function(){
       if (mda.isChild === true) {
           const $sidebarParent = mda.sidebarMenuActive.parent().parent().parent();
           const collapseId = $sidebarParent.siblings('a').attr('href');

           $(collapseId).collapse('show');

           $(collapseId).collapse()
           .on('shown.bs.collapse', () => {
               mda.setMovingTabPosition();
           })
           .on('hidden.bs.collapse', () => {
               mda.setMovingTabPosition();
           });
       }
    },
    animateMovingTab: function(){
        clearTimeout(sidebarTimer);

        const $currentActive = mda.sidebarMenuActive;

        $('.sidebar .nav-container .nav li').removeClass('visible');

        const $movingTab = mda.movingTab;
        $movingTab.addClass('moving');

        $movingTab.css('padding-left', $currentActive.css('padding-left'));
        const button_text = $currentActive.html();

        mda.setMovingTabPosition($currentActive);

        sidebarTimer = setTimeout(function(){
            $movingTab.removeClass('moving');
            $currentActive.parent().addClass('visible');
        }, 650);

        setTimeout(function(){
            $movingTab.html(button_text);
        }, 10);
   },
   moveTab: function(){
       mda.movingTab.css({
           'transform': 'translate3d(0px,' + mda.distance + 'px, 0)',
           '-webkit-transform': 'translate3d(0px,' + mda.distance + 'px, 0)',
           '-moz-transform': 'translate3d(0px,' + mda.distance + 'px, 0)',
           '-ms-transform': 'translate3d(0px,' + mda.distance + 'px, 0)',
           '-o-transform': 'translate3d(0px,' + mda.distance + 'px, 0)'
       });
   }
};