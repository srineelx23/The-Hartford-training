import { Routes } from '@angular/router';
import { Firstcomponent } from './components/firstcomponent/firstcomponent';
import { Secondcomponent } from './components/secondcomponent/secondcomponent';
import { PageNotFound } from './components/page-not-found/page-not-found';
import { ChildA } from './components/child-a/child-a';
import { ChildB } from './components/child-b/child-b';
import { HomeComponent } from './components/home-component/home-component';
import { About } from './components/about/about';


export const routes: Routes = [
    {path:'',redirectTo:'first-component',pathMatch:'full'},
    {path:'first-component', component: Firstcomponent
        ,children:[
            {path:'',redirectTo:'child-a',pathMatch:'full'},
            {path:'child-a',component:ChildA},
            {path:'child-b',component:ChildB}
        ]
    },
    {path:'second-component', component: Secondcomponent,},
     {path:'home',component:HomeComponent},
     {path:'about',component:About},
    {path:'**',component:PageNotFound}
];
