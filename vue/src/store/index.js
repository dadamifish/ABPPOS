﻿import Vue from 'vue';
import Vuex from 'vuex';

import app from './modules/app';
import user from './modules/user';
import session from './modules/session';
import account from './modules/account';
import tenant from './modules/tenant';
import role from './modules/role';
import localization from './modules/localization';
import POSTest from './modules/POSTest';

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
        //
    },
    mutations: {
        //
    },
    actions: {

    },
    modules: {
        app,
        user,
        session,
        account,
        tenant,
        role,
        localization,
        POSTest
    }
});

export default store;
