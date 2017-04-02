$(function(){
  var symbols = {
    show: '', //&#9654;
    hide: '&#9660;'
  }

  $('.hideable').append(' <span class="hideable-icon"></span>')
    .attr('href', '#')
    .find('span.hideable-icon').html(symbols.hide);
  $('.hideable').click(function(e){
    var target = $(this).attr('data-target');
    var $e = $('#' + target);
    if($e.is(':visible')){
      $(this).find('span.hideable-icon').html(symbols.show);
      $e.hide();
    }else{
      $(this).find('span.hideable-icon').html(symbols.hide);
      $e.show().addClass('flash');
    }
    e.preventDefault();
  })

  $('.hideable').click();
});
