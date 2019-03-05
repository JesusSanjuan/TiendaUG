$(document).ready(function () {


    FilePond.registerPlugin(
        FilePondPluginImagePreview
    );

    const inputElement = document.querySelector('input[type="file"]');

    // create a FilePond instance at the input element location
    const pond = FilePond.create(inputElement);

    // attributes have been set to pond options
    /* console.log(pond.name);  // 'filepond'
     console.log(pond.maxFiles); // 10
     console.log(pond.required); // true
     console.log(pond.files);*/


    FilePond.setOptions(
        {
            allowDrop: false,
            allowReplace: false,
            instantUpload: false,
            server: {
                url: 'Admin1.aspx/prueba'
            },
            fileRenameFunction: file => new Promise(resolve => {
                resolve(window.prompt('Enter new filename', file.name));
            })
        });

}); 
