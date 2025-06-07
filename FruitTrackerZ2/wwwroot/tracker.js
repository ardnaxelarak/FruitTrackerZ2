const connection =
    new signalR.HubConnectionBuilder()
        .withUrl("/webview")
        .build();

async function start() {
    try {
        await connection.start();
    } catch (err) {
        console.log(err);
        setTimeout(start, 2000);
    }
}

start();

connection.onclose(async () => setTimeout(start, 2000));

connection.on("UpdateItem", updateItem);

function updateItem(item, images) {
    const $cell = $(`#${item}`);

    $cell.find("img").remove();

    for (const image of images) {
        const img = $('<img>');
        img.addClass("cell-icon");
        img.attr('src', image);
        $cell.append(img);
    }
}
