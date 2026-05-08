// CASO MUDES O NOME DESTE FICHEIRO TENS DE MUDAR TAMBÉM EM PortalUpskill.App\Pages\_Host.cshtml

function SaveAsExcel(filename, fileContent) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64," + fileContent;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

//Ainda não funciona, grava em Excel
function SaveAsCSV(filename, fileContent) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64," + fileContent;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function saveAsFile(filename, fileContent) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = fileContent;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}
