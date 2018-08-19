import * as $ from 'jquery';

export default class Sidebar {
    constructor() {
        this.$toggleBtn = $('.header__toggler-box');
        this.$sidebar =$('.sidebar');
        this.events();
    }

    events() {
        this.$toggleBtn.on('click', this.toggleSidebar.bind(this));
    }

    toggleSidebar() {
        this.$sidebar.toggleClass('sidebar--active');
    }
}