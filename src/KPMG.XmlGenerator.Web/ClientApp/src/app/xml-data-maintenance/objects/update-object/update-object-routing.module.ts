import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UpdateObjectComponent } from './containers';

const routes: Routes = [
  {
    path: '',
    component: UpdateObjectComponent,
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
export class UpdateObjectRoutingModule {}
