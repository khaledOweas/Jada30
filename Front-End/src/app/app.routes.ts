import { Routes } from '@angular/router';
import { SigninComponent } from './components/authentication/classic/sign-in.component';
import { CompanyProfileComponent } from './components/authentication/classic/account/home/company-profile/company-profile.component';
import { AdminOverviewComponent } from './components/admin-overview/admin-overview.component';
import { GetStartedComponent } from './components/home/get-started/get-started.component';
import { SettingsEnterpriseComponent } from './components/home/settings-enterprise/settings-enterprise.component';
import { SignupComponent } from './components/authentication/classic/sign-up/sign-up.component';
import { ChangePasswordComponent } from './components/reset-password/change-password/change-password.component';
import { CheckEmailComponent } from './components/reset-password/check-email/check-email.component';
import { EnterEmailComponent } from './components/reset-password/enter-email/enter-email.component';
import { PasswordChangedComponent } from './components/reset-password/password-changed/password-changed.component';
import { UserProfileComponent } from './components/home/account/user-profile/user-profile.component';

export const routes: Routes = [
    {
        path: 'auth-sign-in',
        component: SigninComponent
    },
    {
        path: 'auth-sign-up',
        component: SignupComponent
    },
    {
        path: 'auth-reset-password-change-password',
        component: ChangePasswordComponent
    },
    {
        path: 'auth-reset-password-check-email',
        component: CheckEmailComponent
    },
    {
        path: 'auth-reset-password-enter-email',
        component: EnterEmailComponent
    },
    {
        path: 'auth-reset-password-password-changed',
        component: PasswordChangedComponent
    },
    {
        path: 'company-profile',
        component: CompanyProfileComponent
    },
    {
        path: '',
        component: AdminOverviewComponent
    },
    {
        path: 'get-started',
        component: GetStartedComponent
    },
    {
        path:'settings-enterprise',
        component: SettingsEnterpriseComponent
    },
    {
        path:'user-profile',
        component: UserProfileComponent
    }
];