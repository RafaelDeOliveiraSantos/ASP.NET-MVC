function ScriptCidade(idUf, idCidade, urlCidade) {
    
    this.iniciar = function() {
        $("#" + idUf).change(function() {
            var uf = $(this).val();
            $.post(urlCidade, { uf: uf }, function(options) {
                $("#" + idCidade).html(options);
            });
        });
    }
}