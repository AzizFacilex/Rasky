import { AbstractControl, ValidatorFn } from '@angular/forms';

// validation function
function validateJuriNameFactory() : ValidatorFn {
  return (c: AbstractControl) => {
    
    let isValid = c.value === 'Juri';

    if(isValid) {
        return null;
    } else {
        return {
            juriName: {
                valid: false
            }
        };
  }
}}