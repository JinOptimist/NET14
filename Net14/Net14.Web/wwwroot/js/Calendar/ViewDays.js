$(document).ready(function () {
    let month = new Date().getMonth() + 1;
    let year = new Date().getFullYear();
    let clickDay;
    const container = document.querySelector('.container');
    let notesWrapper = $('<div>').addClass('notes-wrapper');
    getDays(year, month);
    getNotes(year, month);
    createScrollButtons();
    createDaysOfWeek();
    function getDays(year, month) {
        $.get(`/api/Calendar/GetAllViewDays?year=${year}&&month=${month}`)
            .done(function (dayses) {
                const viewMonth = document.createElement('div');
                let firstIndex = dayses.indexOf(1);
                let lastIndex = dayses.lastIndexOf(1);
                viewMonth.className = 'dayses-month';
                dayses.forEach((item, index) => {

                    const day = document.createElement('span');
                    day.className = 'dayses-day';
                    if (index < firstIndex) {
                        day.classList.remove('dayses-day');
                        day.classList.add('another-day')
                    }
                    if (index >= lastIndex && lastIndex !== firstIndex) {
                        day.classList.remove('dayses-day');
                        day.classList.add('another-day')
                    }


                    day.innerText = item
                    viewMonth.append(day);
                })

                container.append(viewMonth)

            })
    }
    function getNotes(year, month) {
        $.get(`/api/Calendar/MonthNotes?year=${year}&&month=${month}`)
            .done(function (notes) {
                notesWrapper.empty();
                $('.dayses-month').after(notesWrapper);
                if (notes.length === 0) {
                    notesWrapper.append($('<p>').addClass('empty-notes').text('No notes'));
                }
                notes.forEach((note) => {
                    let noteDay = new Date(note.eventDate).getDate();
                    let noteDate = new Date(note.eventDate).toLocaleDateString();
                    const monthNotes = $('<span>').addClass('month-notes');
                    notesWrapper.append(monthNotes);
                    daysesDay = $('.dayses-day');
                    for (let i = 0; i < daysesDay.length; i++) {
                        if (daysesDay[i].innerText == noteDay && !daysesDay[i].classList.contains("another-day")) {
                            daysesDay[i].classList.add('noted');
                            let monthNotesText = $('<span>').addClass('month-notes-text').text(note.text);
                            let monthNotesDate = $('<span>').addClass('month-notes-date').text(noteDate);
                            $(monthNotes).append(monthNotesText);
                            $(monthNotes).append(monthNotesDate);
                        }
                    }
                })
                $('.dayses-day').on('click', viewCurrentNotes)
            })
    }
    function createScrollButtons() {
        const buttonsWrapper = $('<div>').addClass('buttons-wrapper container');
        const prevButton = $('<button>').addClass('prev-button button').text('prev');
        const currentButton = $('<button>').addClass('current-button button').text('current');
        const nextButton = $('<button>').addClass('next-button button').text('next');
        buttonsWrapper.append(prevButton);
        buttonsWrapper.append(currentButton);
        buttonsWrapper.append(nextButton);
        $('.container').after(buttonsWrapper);
    }
    $('.next-button').on('click', function () {
        container.innerHTML = '';
        if (month > 11) {
            month = 1;
            year++;
        }
        else {
            month++;
        }
        getDays(year, month);
        getNotes(year, month);
        console.log(year, month)
    })
    $('.prev-button').on('click', function () {
        container.innerHTML = '';
        if (month <= 1) {
            month = 12;
            year--;
        }
        else {
            month--;
        }

        getDays(year, month);
        getNotes(year, month);
        console.log(year, month)
    })
    $('.current-button').on('click', function () {
        container.innerHTML = '';
        console.log(container);
        month = new Date().getMonth() + 1;
        year = new Date().getFullYear();
        getDays(year, month);
        getNotes(year, month);

    })
    function viewCurrentNotes() {
        document.querySelector('.notes-wrapper').innerHTML = '';
        clickDay = $(this).text();
        $.get(`/Calendar/ViewCurrentNotes?year=${year}&&month=${month}&&day=${clickDay}`)
            .done(function (notes) {
                if (notes.length === 0) {
                    notesWrapper.append($('<p>').addClass('empty-notes').text('No notes'));
                }
                for (let i = 0; i < notes.length; i++) {
                    let currentNoteBlock = $('<div>').addClass('current-note-block');
                    let monthNotesText = $('<span>').addClass('current-notes-text').text(notes[i]);
                    let deleteNoteButton = $('<button>').addClass('delete-note-button').text('Delete').attr('note-text', notes[i]);
                    currentNoteBlock.append(monthNotesText);
                    currentNoteBlock.append(deleteNoteButton);
                    notesWrapper.append(currentNoteBlock);
                }
                $('.delete-note-button').on('click', function () {
                    document.querySelector('.notes-wrapper').innerHTML = '';
                    $.post(`/api/Calendar/DeleteNote?text=${$(this).attr('note-text')}&&day=${clickDay}&&month=${month}&&year=${year}`)
                        .done(function (note) {
                            viewCurrentNotes();
                        })
            });
        
        })
        addNote();
    }
    function createDaysOfWeek() {
        let daysOfWeek = document.createElement('div')
        daysOfWeek.className = 'days-of-week container';
        container.before(daysOfWeek);
        let daysOfWeekText = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'];
        daysOfWeekText.forEach((day) => {
            let dayOfWeek = document.createElement('span');
            dayOfWeek.className = 'day-of-week';
            dayOfWeek.innerText = day;
            daysOfWeek.append(dayOfWeek);
        });


    }
    function addNote() {
        let addNoteButton = document.createElement('button');
        addNoteButton.className = 'add-note-button';
        addNoteButton.innerText = 'Add note';
        notesWrapper.append(addNoteButton);

        $(addNoteButton).on('click', function () {
            document.querySelector('.notes-wrapper').innerHTML = '';
            let addNoteForm = $('<form>').addClass('add-note-form');
            let addNoteTextarea = $('<textarea>').addClass('add-note-textarea');
            let addNoteButtonInForm = $('<button>').addClass('add-note-button-form').text('Add note');
            let addIsImportant = $(`<input type="checkbox" name="isImportant" class="isImportant">`);
            addNoteForm.append(addNoteTextarea);
            addNoteForm.append(addNoteButtonInForm);
            addNoteForm.append(addIsImportant);
            notesWrapper.append(addNoteForm);
            $(addNoteButtonInForm).on('click', function () {
                let noteText = $('.add-note-textarea').val();
                let isImportant = $('.isImportant').prop('checked');
                $.post(`/api/Calendar/AddNote?text=${noteText}&&day=${clickDay}&&isImportant=${isImportant}`)
                    .done(function (note) {
                        viewCurrentNotes();
                    })
            })
        })

    }
    
})
