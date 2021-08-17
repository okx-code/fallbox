function showText(e) {
    const minArea = e.querySelector(".textarea-min");
    const maxArea = e.querySelector(".textarea-max");
    minArea.classList.add("invisible");
    maxArea.classList.remove("invisible");
    maxArea.focus();
}
function hideText(e) {
    const minArea = e.querySelector(".textarea-min");
    const maxArea = e.querySelector(".textarea-max");
    minArea.classList.remove("invisible");
    maxArea.classList.add("invisible");
}
function del(e, id) {
    const xhr = new XMLHttpRequest();
    xhr.open("DELETE", "delete?id=" + id, true);
    xhr.onreadystatechange = function () {
        // In local files, status is 0 upon success in Mozilla Firefox
        if (xhr.readyState === XMLHttpRequest.DONE) {
            var status = xhr.status;
            if (status === 0 || (status >= 200 && status < 400)) {
                e.remove();
                console.log("Removed: " + id);
            }
            else {
                e.classList.remove("invisible");
            }
        }
    };
    xhr.send();
    e.classList.add("invisible");
}
//# sourceMappingURL=app.js.map