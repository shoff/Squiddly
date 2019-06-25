import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
  { path: '', component: LayoutComponent, children: [
    { path: '', loadChildren: '../home/home.module#HomeModule'},
    { path: 'events', loadChildren: '../events/events.module#EventsModule'}
  ]}];
    //   { path: '', component: HomeComponent, pathMatch: 'full' },
    //   { path: 'counter', component: CounterComponent },
    //   { path: 'fetch-data', component: FetchDataComponent },
    //   { path: 'projects', component: ProjectComponent }
    // ])

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
