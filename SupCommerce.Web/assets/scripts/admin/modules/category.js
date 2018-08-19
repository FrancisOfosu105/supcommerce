import Vue from 'vue';
import Vuelidate from 'vuelidate';
import {required} from 'vuelidate/lib/validators';

Vue.use(Vuelidate);

new Vue({
    el: '#app',
    data: {
        name: null
    },
    validations: {
        name: {
            required
        }
    }
});
