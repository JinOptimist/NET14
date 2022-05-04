$(document).ready(function () {
    let notesdb = [];
    const year = +$('.thisYear').text()
    const month = +$('.thisMonth').text()
    let day
    $('.day').on('click', createNotesBlocks)



    

    function createNotesBlocks() {
        
        if (day === $(this).text()) {
            $('.notes-block').detach()
            day = 0
        } else {

            $('.notes-block').detach()
            day = $(this).text()
            $.get(`/Calendar/ViewCurrentNotes?year=${year}&&month=${month}&&day=${day}`)
                .done(function (notes) {
                    for (let i = 0; i <= notes.length; i++) {
                        const notesBlock = $('<div>');
                        notesBlock.addClass('notes-block');
                        notesBlock.html(notes[i])
                        $('.wrapper').after(notesBlock)
                    }

                });
        }
    }
})