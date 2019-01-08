import { Component, OnInit, OnChanges, AfterViewInit } from '@angular/core';
import { ApiService } from '../../services/apiservices';
import { User } from '../../services/models/userModel';

declare var $: any;
interface FileReaderEventTarget extends EventTarget {
    result: string;
}
interface FileReaderEvent extends Event {
    target: FileReaderEventTarget;
    getMessage(): string;
}

@Component({
    selector: 'app-applicantprofile',
    templateUrl: './applicantprofile.component.html'
})
export class ApplicantProfileComponent implements OnInit, OnChanges, AfterViewInit {
    id = sessionStorage.getItem('User');
    readURL(input) {
        if (input.files && input.files[0]) {
            const reader = new FileReader();

            reader.onload = function (e: FileReaderEvent) {
                $('#wizardPicturePreview').attr('src', e.target.result).fadeIn('slow');
            };
            reader.readAsDataURL(input.files[0]);
        }
    }
    // tslint:disable-next-line:member-ordering
    public user: User;
    constructor(private apiservices: ApiService) { }

    ngOnInit() {
        // Code for the Validator
        this.apiservices.getProfile(this.id).then(x => {
            this.user = x;
        });
        // date picker code
        if ($('.tagsinput').length !== 0) {
            $('.tagsinput').tagsinput();
        }

        //  Init Bootstrap Select Picker
        if ($('.selectpicker').length !== 0) {
            $('.selectpicker').selectpicker();
        }
        $('.datepicker').datetimepicker({
            format: 'MM/DD/YYYY',
            icons: {
                time: 'fa fa-clock-o',
                date: 'fa fa-calendar',
                up: 'fa fa-chevron-up',
                down: 'fa fa-chevron-down',
                previous: 'fa fa-chevron-left',
                next: 'fa fa-chevron-right',
                today: 'fa fa-screenshot',
                clear: 'fa fa-trash',
                close: 'fa fa-remove',
                inline: true
            }
        });

        // date end
        const $validator = $('.wizard-card form').validate({
            rules: {
                firstname: {
                    required: true,
                    minlength: 3
                },
                lastname: {
                    required: true,
                    minlength: 3
                },
                email: {
                    required: true,
                    minlength: 3,
                }
            },
            errorPlacement: function (error, element) {
                $(element).parent('div').addClass('has-error');
            }
        });
        $('.wizard-card').bootstrapWizard({
            'tabClass': 'nav nav-pills',
            'nextSelector': '.btn-next',
            'previousSelector': '.btn-previous',

            onNext: function (tab, navigation, index) {
                const $valid = $('.wizard-card form').valid();
                if (!$valid) {
                    $validator.focusInvalid();
                    return false;
                }
            },

            onInit: function (tab, navigation, index) {

                // check number of tabs and fill the entire row
                const $total = navigation.find('li').length;
                let $width = 100 / $total;
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
                $('.moving-tab').css({
                    'transform': 'translate3d(' + move_distance + 'px, 0, 0)',
                    'transition': 'all 0.5s cubic-bezier(0.29, 1.42, 0.79, 1)'

                });

                $('.moving-tab').css('transition', 'transform 0s');
            },

            onTabClick: function (tab, navigation, index) {

                const $valid = $('.wizard-card form').valid();

                if (!$valid) {
                    return false;
                } else {
                    return true;
                }
            },

            onTabShow: function (tab, navigation, index) {
                const $total = navigation.find('li').length;
                let $current = index + 1;

                const $wizard = navigation.closest('.wizard-card');

                // If it's the last tab then hide the last button and show the finish instead
                if ($current >= $total) {
                    $($wizard).find('.btn-next').hide();
                    $($wizard).find('.btn-finish').show();
                } else {
                    $($wizard).find('.btn-next').show();
                    $($wizard).find('.btn-finish').hide();
                }

                const button_text = navigation.find('li:nth-child(' + $current + ') a').html();

                setTimeout(function () {
                    $('.moving-tab').text(button_text);
                }, 150);

                const checkbox = $('.footer-checkbox');

                if (index !== 0) {
                    $(checkbox).css({
                        'opacity': '0',
                        'visibility': 'hidden',
                        'position': 'absolute'
                    });
                } else {
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
                $('.moving-tab').css({
                    'transform': 'translate3d(' + move_distance + 'px, 0, 0)',
                    'transition': 'all 0.5s cubic-bezier(0.29, 1.42, 0.79, 1)'

                });
            }
        });


        // Prepare the preview for profile picture
        $('#wizard-picture').change(function () {

            this.readURL(this);
        });

        $('[data-toggle="wizard-radio"]').click(function () {
            console.log('click');

            const wizard = $(this).closest('.wizard-card');
            wizard.find('[data-toggle="wizard-radio"]').removeClass('active');
            $(this).addClass('active');
            $(wizard).find('[type="radio"]').removeAttr('checked');
            $(this).find('[type="radio"]').attr('checked', 'true');
        });

        $('[data-toggle="wizard-checkbox"]').click(function () {
            if ($(this).hasClass('active')) {
                $(this).removeClass('active');
                $(this).find('[type="checkbox"]').removeAttr('checked');
            } else {
                $(this).addClass('active');
                $(this).find('[type="checkbox"]').attr('checked', 'true');
            }
        });

        $('.set-full-height').css('height', 'auto');

    }

    ngOnChanges() {
        const input = $(this);
        // tslint:disable-next-line:no-var-keyword
        var target: EventTarget;
        if (input.files && input.files[0]) {
            const reader: any = new FileReader();

            reader.onload = function (e) {
                $('#wizardPicturePreview').attr('src', e.target.result).fadeIn('slow');
            };
            reader.readAsDataURL(input.files[0]);
        }
    }
    ngAfterViewInit() {
        $('.wizard-card').each(function () {

            const $wizard = $(this);
            const index = $wizard.bootstrapWizard('currentIndex');
            // this.refreshAnimation($wizard, index);

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
            $('.moving-tab').css({
                'transform': 'translate3d(' + move_distance + 'px, 0, 0)',
                'transition': 'all 0.5s cubic-bezier(0.29, 1.42, 0.79, 1)'

            });

            $('.moving-tab').css({
                'transition': 'transform 0s'
            });
        });
    }
    changeImage(e) {
        console.log(e);
        // let fileList: FileList = e.target.files;
        // console.log(fileList[0].name);
        // if (fileList.length > 0) {
        //     const file: File = fileList[0];
        //     const formData: FormData = new FormData();
        //     formData.append('uploadFile', file, file.name);
        //     console.log()
        //     this.path = "../assets/images/" + file.name;
        //     console.log(this.path);
        // }
    }
}
