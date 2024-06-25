$(document).ready(function () {
  $(".checkbox-tarefa").change(function () {
    var tr = $(this).closest("tr");

    if ($(this).prop("checked")) {
      // Adiciona classes para estilizar a linha como concluída
      tr.addClass("tarefa-concluida");
    } else {
      // Remove as classes se a checkbox for desmarcada
      tr.removeClass("tarefa-concluida");
    }
  });
});
