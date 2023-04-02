import {Component, Input, OnInit} from '@angular/core';
import {FormControl} from "@angular/forms";
import {map, Observable, startWith} from "rxjs";

@Component({
  selector: 'app-auto-complete',
  templateUrl: './auto-complete.component.html',
  styleUrls: ['./auto-complete.component.scss']
})
export class AutoCompleteComponent implements OnInit {
  @Input() data!: any[];
  @Input() propertyNameOne!: string;
  @Input() propertyNameTwo!: string;
  @Input() placeholder: string = "Search";
  @Input() initialValue: any;
  filteredOptions!: Observable<any[]>;
  control: FormControl = new FormControl();

  ngOnInit(): void {
    this.filteredOptions = this.control.valueChanges
    .pipe(
      startWith(''),
      map(value => this._filter(value))
    );
  }

  private _filter(value: string) {
    const filterValue = value.toLowerCase();
    return this.data.filter(option => {
      const optionValue1 = option[this.propertyNameOne].toLowerCase()
      const optionValue2 = option[this.propertyNameTwo].toLowerCase()
      return optionValue1.includes(filterValue) || optionValue2.includes(filterValue);
    });
  }

  emitValue() {
    console.log(this.control.value)
  }
}
