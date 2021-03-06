import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateObjectComponent } from './containers';

const routes: Routes = [
  {
    path: '',
    component: CreateObjectComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('./../object-forms/object-forms.module').then(m => m.ObjectFormsModule),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CreateObjectRoutingModule {}
