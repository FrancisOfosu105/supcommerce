import $ from 'jquery';

export default class FileInput {
    constructor() {
        this.$fileInput = $('.js-file-input');
        this.$previewBox = $('.js-display-image');
        this.events();
    }

    events() {
        this.$fileInput.on('change', this.displayImage.bind(this));
    }


    displayImage(evt) {
        const input = evt.target;
        if (input.files && input.files[0]) {
            const fileReader = new FileReader();
            fileReader.onload = ev => {
                this.$previewBox.attr('src', ev.target.result);
            };

            fileReader.readAsDataURL(input.files[0]);
        }
    }
}