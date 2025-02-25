import { Component, EventEmitter, forwardRef, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ControlValueAccessor, NG_VALUE_ACCESSOR,ReactiveFormsModule,
  FormControl 
 } from '@angular/forms';

@Component({
    selector: 'jada-input',
    imports: [CommonModule,ReactiveFormsModule ],
    templateUrl: './jada-input.component.html',
    styleUrl: './jada-input.component.scss',
    standalone: true,
    providers: [
      {
        provide: NG_VALUE_ACCESSOR,
        useExisting: forwardRef(() => JadaInputComponent),
        multi: true
      }
    ]
})
export class JadaInputComponent implements OnInit, OnChanges, ControlValueAccessor {
  @Input() language: 'arabic' | 'english' = 'english';
  @Input() mode: 'dark' | 'light' = 'light';
  @Input() header: 'true' | 'false' = 'true';
  @Input() headertext: string = 'Main Title';
  @Input() type: 'phone' | 'regular' | 'currency' = 'regular';
  @Input() caption: 'true' | 'false' = 'true';
  @Input() caption_text: string = 'Sub Title';
  @Input() required: 'true' | 'false' = 'true';
  @Input() status: 'disabled' | 'success' | 'default' | 'value' | 'error' | 'focus' = 'default';
  @Input() icon: 'true' | 'false' = 'true';
  @Input() actionicon: 'true' | 'false' = 'true';
  @Input() background: string = '';
  @Input() label: string="";
  @Input() name: string="";
  @Input() placeholder: string = 'Place Holder';
  @Output() valueChange = new EventEmitter<string>();

  oldStatus: 'disabled' | 'success' | 'default' | 'value' | 'error' | 'focus' = 'default';
  xmarkvisible: 'visibled' | 'invisibled' = 'visibled';
  
  value: string = '';
  onChange: any = () => {};
  onTouched: any = () => {};

  ///
  @Input() formControl: FormControl=new FormControl;
  @Input() requiredErrorMessage: string = 'This field is required.';
  @Input() minLengthErrorMessage: string = 'The minimum length is ';
  @Input() maxLengthErrorMessage: string = 'The maximum length is ';
  @Input() patternErrorMessage: string = 'The input does not match the required pattern.';
  @Input() emailErrorMessage: string = 'The input does not match email pattern.';

  ///
  ngOnInit() {
    this.updateXmarkVisibility();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['value']) {
      this.updateXmarkVisibility();
    }
  }

  writeValue(value: string): void {
    this.value = value;
    this.updateXmarkVisibility();
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.status = isDisabled ? 'disabled' : 'default';
  }

  getCircleIconColorBasedOnStatus(status: string): string {
    switch (status) {
      case 'disabled':
        return 'var(--noble-black-secondary-noble-black-tone-30, #DCE0E3)';
      case 'success':
        return 'var(--noble-black-secondary-noble-black-tone-40, #B9BDC0)';
      case 'value':
      case 'focus':
        return 'var(--sea-blue-primary-normal-blue, #02618D)';
      case 'error':
      default:
        return 'var(--noble-black-secondary-noble-black-tone-40, #B9BDC0)';
    }
  }

  getCloseIconColorBasedOnStatus(status: string): string {
    switch (status) {
      case 'disabled':
        return 'var(--noble-black-secondary-noble-black-tone-30, #DCE0E3)';
      case 'success':
      case 'error':
        return 'var(--noble-black-secondary-noble-black-tone-50, #9A9EA1)';
      case 'value':
      case 'focus':
        return 'var(--sea-blue-primary-normal-blue, #02618D)';
      default:
        return 'var(--noble-black-secondary-noble-black-tone-40, #B9BDC0)';
    }
  }

  onInputFocus() {
    this.oldStatus = this.status;
    this.status = this.status ==="error" ? 'error':'focus';
    this.onTouched();
  }

  onInputBlur() {
    this.status = this.oldStatus;
  }

  updateXmarkVisibility() {
    this.xmarkvisible = this.value === '' ? 'invisibled' : 'visibled';
  }

  onClose() {
    this.value = '';
    this.xmarkvisible = 'invisibled';
    this.onChange(this.value);
    this.valueChange.emit(this.value);
  }

  handleChange(event: Event) {
    const input = event.target as HTMLInputElement;
    this.value = input.value;
    this.updateXmarkVisibility();
    this.onChange(this.value);
    this.valueChange.emit(this.value);
  }
 // Method to check if the FormControl has a required validator
 // Method to check if the FormControl has a required validator
 hasRequiredValidator(): boolean {
  const validators = this.formControl.validator ? [this.formControl.validator] : []; // Get the validator function and wrap it in an array
  return validators.some(validator => {
    const validationResult = validator(this.formControl); // Call the validator
    return validationResult && validationResult['required'] !== undefined; // Check if 'required' key exists
  });
}
}