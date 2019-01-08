import { Component, OnInit, OnChanges, AfterViewInit } from '@angular/core';
import { ApiService } from '../../services/apiservices';
import { Route, ActivatedRoute, Router } from '@angular/router';
import { Application } from '../../services/models/applicationModel';
import { UserService } from '../../services/user.services';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { from } from 'rxjs/observable/from';
// import { QuestionAnswer } from '../../services/models/QuestionAnswerModel';
import { Question } from '../../services/models/questionModel';
import { ApplicationQuestions } from '../../services/models/ApplicationQuestionsModel';
import { QuestionAnswer } from '../../services/models/QuestionAnswerModel';
declare var $: any;
declare var swal:any;
interface FileReaderEventTarget extends EventTarget {
    result: string;
}
interface FileReaderEvent extends Event {
    target: FileReaderEventTarget;
    getMessage(): string;
}

@Component({
    moduleId: module.id,
    // tslint:disable-next-line:component-selector
    selector: 'grid-cmp',
    templateUrl: 'award.component.html'
})

export class AwardComponent implements OnInit, OnChanges, AfterViewInit {
    private applicationDetail: ApplicationQuestions;
    public myForm: FormGroup;
    username=sessionStorage.getItem('User-name');
    constructor(public apiservies: ApiService, private user: UserService, private route: ActivatedRoute, private _fb: FormBuilder,private _router:Router) { }
    ngOnInit() {
        this.myForm = this._fb.group({
            AwardId: [this.route.snapshot.paramMap.get('id')],
            que: this._fb.array([])
        });
        this.apiservies.getAward(this.route.snapshot.paramMap.get('id')).then((x) => {
            x.Questions.forEach(element => {
                this.addAddress(element.QueId);
            });
        });
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
    // code for temp file loop
    addAddress(i: any) {
        const control = <FormArray>this.myForm.controls['que'];
        // const addrCtrl = this.initAddress(i);
        control.push(this._fb.group({
            QueId: [i],
            Answer: ['']
        }));
    }
    ngOnChanges() {
        const input = $(this);
        // tslint:disable-next-line:prefer-const
        let target: EventTarget;
        if (input.files && input.files[0]) {
            const reader: any = new FileReader();

            reader.onload = function (e) {
                $('#wizardPicturePreview').attr('src', e.target.result).fadeIn('slow');
            };
            reader.readAsDataURL(input.files[0]);
        }
    }
    ApplyAward() {
        console.log(this.myForm.get('que').value);
        this.applicationDetail = new ApplicationQuestions();
        this.applicationDetail.AwdId = this.myForm.get('AwardId').value;
        this.applicationDetail.Stage = 1;
        this.applicationDetail.UserId = sessionStorage.getItem('User');
        this.applicationDetail.AppliedDate = new Date();
        this.applicationDetail.QuestionAnswer = this.myForm.get('que').value;
        this.applicationDetail.isRejected = false;
        this.user.PostApplication(this.applicationDetail).subscribe((res) => {
            res = res;
        });
        swal({
            title: 'Success',
            text: "Application submit successfull",
            type: 'success',
            //showCancelButton: true,
            confirmButtonClass: 'btn btn-success',
            //cancelButtonClass: 'btn btn-danger',
            confirmButtonText: 'OK',
            buttonsStyling: false
        }).then(function() {
            window.location.href = 'jurydashboard';
        });
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
}
