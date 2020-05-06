import {Directive} from "@angular/core";
import {AbstractControl, NG_VALIDATORS, ValidationErrors, Validator} from "@angular/forms";


@Directive({
  selector: '[vali][ngModel]',
  providers: [
    {
      provide: NG_VALIDATORS,
      useExisting: ValiDirective,
      multi: true
    }
  ]

})
export class ValiDirective implements Validator {

  validate(formControl: AbstractControl): ValidationErrors {
    if(formControl.value.name === '3'){
      return {vali: { error: 'vali'}}
    }
    return null;
  };
}
