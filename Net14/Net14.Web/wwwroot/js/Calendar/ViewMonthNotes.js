$(document).ready(function () {
    let month = new Date().getMonth() + 1;
    let year = new Date().getFullYear();
    getNotes();
    function getNotes() {
        $.get(`/api/Calendar/MonthNotes?year=${year}&&month=${month}`)
            .done(function (notes) {
                const notesWrapper = $('<div>').addClass('notes-wrapper');
                notes.forEach((note) => {
                    let noteDay = new Date(note.eventDate).getDate();
                    let noteDate = new Date(note.eventDate).toLocaleDateString();
                    const monthNotes = $('<span>').addClass('month-notes');
                    notesWrapper.append(monthNotes);
                    a = $('.dayses-day');
                    for (let i = 0; i < a.length; i++) {
                        if (a[i].innerText == noteDay && !a[i].classList.contains("another-day")) {
                            a[i].classList.add('noted');
                            let monthNotesText = $('<span>').addClass('month-notes-text').text(note.text);
                            let monthNotesDate = $('<span>').addClass('month-notes-date').text(noteDate);
                            $(monthNotes).append(monthNotesText);
                            $(monthNotes).append(monthNotesDate);
                            console.log(noteDate)
                        }
                    }
                    
                    $('.container').append(notesWrapper);
                })
            })
    }
})