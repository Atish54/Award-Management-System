import { Component, OnInit, OnChanges, AfterViewInit } from '@angular/core';
import { Router, Routes} from '@angular/router';
import { ApiService } from '../../services/apiservices';

declare var $: any;
interface FileReaderEventTarget extends EventTarget  {
    result: string;
}
interface FileReaderEvent extends Event  {
    target: FileReaderEventTarget;
    getMessage(): string;
}

@Component( {
    moduleId: module.id,
    // tslint:disable-next-line:component-selector
    selector: 'grid-cmp',
    templateUrl: 'apply.component.html'
})

export class ApplyComponent implements OnInit, OnChanges, AfterViewInit {
    readURL(input)  {
        if (input.files && input.files[0])  {
            const reader = new FileReader();
            reader.onload = function (e: FileReaderEvent)  {
                $('#wizardPicturePreview').attr('src', e.target.result).fadeIn('slow');
            };
            reader.readAsDataURL(input.files[0]);
        }
    }
    constructor(private _router: Router, public _apiservices: ApiService) {}
    // function of edit button
    newpath(id: any) {
        // console.log('running......');
        this._router.navigate(['/user/award/', id]);
    }

    ngOnInit() {
        // Code for the Validator
        this._apiservices.getCategories();
         //  Init Bootstrap Select Picker

         setTimeout(function(){
            $('#datatables1') .DataTable({
                'pagingType': 'full_numbers',
                'lengthMenu': [[10, 25, 50, -1], [10, 25, 50, 'All']],
                responsive: true,
                language: {
                search: '_INPUT_',
                searchPlaceholder: 'Search records',
                }

            }) ;
            const table = $('#datatables1') .DataTable() ;

            // Edit record
            table.on( 'click', '.edit', function ()  {
                const $tr = $(this) .closest('tr') ;

                const data = table.row($tr) .data() ;
                alert( 'You press on Row: ' + data[0] + ' ' + data[1] + ' ' + data[2] + '\'s row.' ) ;
            } ) ;

            // Delete a record
            table.on( 'click', '.remove', function (e)  {
                const $tr = $(this) .closest('tr') ;
                table.row($tr) .remove() .draw() ;
                e.preventDefault() ;
            } ) ;

            // Like record
            table.on( 'click', '.like', function ()  {
                alert('You clicked on Like button') ;
            }) ;

            //  Activate the tooltips
            $('[rel="tooltip"]') .tooltip() ;
          }
          , 2000);

        // this._apiservices.getAwardlist();


        const $validator = $('.wizard-card form').validate( {
            rules:  {
                  firstname:  {
                      required: true,
                      minlength: 3
                    },
                    lastname:  {
                        required: true,
                        minlength: 3
                    },
                    email:  {
                        required: true,
                        minlength: 3,
                    }
                },

            errorPlacement: function(error, element)  {
                $(element).parent('div').addClass('has-error');
             }
        });
        $('.wizard-card').bootstrapWizard( {
            'tabClass': 'nav nav-pills',
            'nextSelector': '.btn-next',
            'previousSelector': '.btn-previous',

            onNext: function(tab, navigation, index)  {
                const $valid = $('.wizard-card form').valid();
                if (!$valid)  {
                    $validator.focusInvalid();
                    return false;
                }
            },

            onInit : function(tab, navigation, index) {

              // check number of tabs and fill the entire row
              const $total = navigation.find('li').length;
              let  $width = 100 / $total;
              const $wizard = navigation.closest('.wizard-card');

              const $display_width = $(document).width();

              if ($display_width < 600 && $total > 3) {
                  $width = 50;
              }

               navigation.find('li').css('width', $width + '%');
               const $first_li = navigation.find('li:first-child a').html();
               const $moving_div = $('<div class="moving-tab">' + $first_li + '</div>');
               $('.wizard-card .wizard-navigation').append($moving_div);

            //    this.refreshAnimation($wizard, index);
            const total_steps = $wizard.find('li').length;
            let move_distance = $wizard.width() / total_steps;
            const step_width = move_distance;
            move_distance *= index;

            const $current = index + 1;

            if ($current === 1) {
                move_distance -= 8;
            } else if ($current === total_steps) {
                move_distance += 8;
            }

            $wizard.find('.moving-tab').css('width', step_width);
            $('.moving-tab').css( {
                'transform': 'translate3d(' + move_distance + 'px, 0, 0)',
                'transition': 'all 0.5s cubic-bezier(0.29, 1.42, 0.79, 1)'

            });

               $('.moving-tab').css('transition', 'transform 0s');
           },

            onTabClick : function(tab, navigation, index) {

                const $valid = $('.wizard-card form').valid();

                if (!$valid) {
                    return false;
                } else {
                    return true;
                }
            },

            onTabShow: function(tab, navigation, index)  {
                const $total = navigation.find('li').length;
                let $current = index + 1;

                const $wizard = navigation.closest('.wizard-card');

                // If it's the last tab then hide the last button and show the finish instead
                if ($current >= $total)  {
                    $($wizard).find('.btn-next').hide();
                    $($wizard).find('.btn-finish').show();
                } else  {
                    $($wizard).find('.btn-next').show();
                    $($wizard).find('.btn-finish').hide();
                }

                const button_text = navigation.find('li:nth-child(' + $current + ') a').html();

                setTimeout(function() {
                    $('.moving-tab').text(button_text);
                }, 150);

                const checkbox = $('.footer-checkbox');

                if ( index !== 0 ) {
                    $(checkbox).css({
                        'opacity': '0',
                        'visibility': 'hidden',
                        'position': 'absolute'
                    });
                } else  {
                    $(checkbox).css({
                        'opacity': '1',
                        'visibility': 'visible'
                    });
                }

                // this.refreshAnimation($wizard, index);
                const total_steps = $wizard.find('li').length;
                let move_distance = $wizard.width() / total_steps;
                const step_width = move_distance;
                move_distance *= index;

                $current = index + 1;

                if ($current === 1) {
                    move_distance -= 8;
                } else if ($current === total_steps) {
                    move_distance += 8;
                }

                $wizard.find('.moving-tab').css('width', step_width);
                $('.moving-tab').css( {
                    'transform': 'translate3d(' + move_distance + 'px, 0, 0)',
                    'transition': 'all 0.5s cubic-bezier(0.29, 1.42, 0.79, 1)'

                });
            }
        });
        // Prepare the preview for profile picture
        $('#wizard-picture').change(function() {

            this.readURL(this);
        });

        $('[data-toggle="wizard-radio"]').click(function() {
            console.log('click');

            const wizard = $(this).closest('.wizard-card');
            wizard.find('[data-toggle="wizard-radio"]').removeClass('active');
            $(this).addClass('active');
            $(wizard).find('[type="radio"]').removeAttr('checked');
            $(this).find('[type="radio"]').attr('checked', 'true');
        });

        $('[data-toggle="wizard-checkbox"]').click(function() {
            if ( $(this).hasClass('active'))  {
                $(this).removeClass('active');
                $(this).find('[type="checkbox"]').removeAttr('checked');
            } else  {
                $(this).addClass('active');
                $(this).find('[type="checkbox"]').attr('checked', 'true');
            }
        });

        $('.set-full-height').css('height', 'auto');

    }

    ngOnChanges()  {
        const input = $(this);
        // tslint:disable-next-line:prefer-const
        let target: EventTarget;
        if (input.files && input.files[0])  {
            const reader: any = new FileReader();


            reader.onload = function (e)  {
                $('#wizardPicturePreview').attr('src', e.target.result).fadeIn('slow');
            };
            reader.readAsDataURL(input.files[0]);
        }
    //   debugger;
        if ($('.selectpicker').length !== 0)  {
            $('.selectpicker').selectpicker();
        }
    }
    ngAfterViewInit()  {
        $('.wizard-card').each(function() {

            const $wizard = $(this);
            const index = $wizard.bootstrapWizard('currentIndex');
            // this.refreshAnimation($wizard, index);

            const total_steps = $wizard.find('li').length;
            let move_distance = $wizard.width() / total_steps;
            const step_width = move_distance;
            move_distance *= index;

            const $current = index + 1;

            if ($current === 1)  {
                move_distance -= 8;
            } else if ($current === total_steps)  {
                move_distance += 8;
            }

            $wizard.find('.moving-tab').css('width', step_width);
            $('.moving-tab').css( {
                'transform': 'translate3d(' + move_distance + 'px, 0, 0)',
                'transition': 'all 0.5s cubic-bezier(0.29, 1.42, 0.79, 1)'

            });

            $('.moving-tab').css( {
                'transition': 'transform 0s'
            });
        });

    }
    onChangeCate(event)  {
        const val = event.target.value;
        this._apiservices.getSubCategories(val);
       setTimeout(() => {
        if ($('.selectpicker').length !== 0)  {
            $('.selectpicker').selectpicker('refresh');
        }
       }, 300);
    }
    subcateChnge(event) {

        const val = event.target.value;
        this._apiservices.getAwardList(val);
        // $('.selectpicker').selectpicker('refresh');
    }
}
