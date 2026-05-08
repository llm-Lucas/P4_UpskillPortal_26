function ExcelSaveAs(filename, fileContent) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64," + fileContent
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}