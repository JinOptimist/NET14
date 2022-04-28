$(document).ready(function () {

    let dayNotes = [];

    function collectNotes() {
        $.get('/Calendar/ViewCurrentNotes')
            .done(function (notes) {
                dayNotes = notes

                createNotesBlock(dayNotes);
            })
    }

    function createNoteBlock(myNotes) {
        for (let i = 0; i <= myNotes.length; i++) {
            let note = myNotes[i];

            const noteBlock = $('<div>');
            noteBlock.addClass('note-block');
        }
    }