$(document).ready(function () {
    $(document).on("click", ".friend-status-blocked", function () {
        let blockButton = $(this);
        let userToBlock = $(this).closest(".find-recomendation-element-menu");
        let id = userToBlock.data("friend");

        $.get("/api/Social/BlockUser", { userId: id })
            .done(function () {
                userToBlock.addClass("blocked");
                blockButton.text("Unblock");
                blockButton.removeClass("friend-status-blocked").addClass("friend-status-unblocked");
            })
    })

    $(document).on("click", ".friend-status-unblocked", function () {
        let unblockButton = $(this);
        let userToUnblock = $(this).closest(".find-recomendation-element-menu.blocked");
        let id = userToUnblock.data("friend");

        $.get("/api/Social/UnblockUser", { userId: id })
            .done(function () {
                userToUnblock.removeClass("blocked");
                unblockButton.text("Block");
                unblockButton.removeClass("friend-status-unblocked").addClass("friend-status-blocked");
            })
    })
})