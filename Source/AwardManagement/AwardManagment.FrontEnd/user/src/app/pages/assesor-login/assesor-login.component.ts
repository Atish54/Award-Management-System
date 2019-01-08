import { Component, OnInit } from '@angular/core';

declare var $: any;
@Component({
  selector: 'app-assesor-login',
  templateUrl: './assesor-login.component.html'
})
export class AssesorLoginComponent implements OnInit {
  test: Date = new Date();

  checkFullPageBackgroundImage() {
      // tslint:disable-next-line:prefer-const
      let $page = $('.full-page');
      const image_src = $page.data('image');

      if (image_src !== undefined) {
          const image_container = '<div class="full-page-background" style="background-image: url(' + image_src + ') "/>';
          $page.append(image_container);
      }
  };
  ngOnInit() {
      this.checkFullPageBackgroundImage();

      setTimeout(function(){
          // after 1000 ms we add the class animated to the login/register card
          $('.card').removeClass('card-hidden');
      }, 700);
  }

}
