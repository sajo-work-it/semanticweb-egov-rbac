
(function ($) {
    $.fn.ServerDataTable = function (options) {
        // Default options
        var default_edit_btn_html = "";//"<button type='button' class='btn btn-success btn-edit'><i class='fa fa-edit'></i> Edit</button>";
        var default_info_btn_html = "";//"<button type='button' class='btn btn-info btn-info'><i class='fa fa-info'></i> Info.</button>";
        var default_delete_btn_html = "";//"<button type='button' class='btn btn-danger btn-delete'><i class='fa fa-trash'></i> Delete</button>";

        var default_btns_html = "";//default_edit_btn_html + default_info_btn_html + default_delete_btn_html;
        var editBtn_ = { show: true, text: "Edit", clickHandler: function (rowData) { } };
        if (options.editBtn) {
            editBtn_ = $.extend({}, { show: true, text: "Edit", clickHandler: function (rowData) { } }, options.editBtn);
            //alert("1#### "+JSON.stringify(editBtn_));
        }
        var settings = $.extend({
            baseUrl: "",
            ajaxUrl: "Read",
            editUrl: "Edit",
            infoUrl: "Details",
            disableModalClose: false,
            deleteUrl: "Delete",
            containerModalId: "#modal-content",
            modalId: "#modal",
            editBtn: { show: true, clickHandler: function (rowData, e) { }, editButtonCssClass: "", },// $.extend({}, { show: true, text: "Edit", clickHandler: function (rowData) { } }, options.editBtn),
            infoBtn: { show: true, clickHandler: function (rowData, e) { } },
            deleteBtn: { show: true, clickHandler: function (rowData, e) { }, deleteButtonCssClass: "", },
            scrollX: true,
            scrollY: false,
            //customButtons: [{ text: "New", cssClass: "btn btn-sm btn-default", fa_icon: 'fa fa-pencil', handler: function (data) { } }],
            //customButtons: [{ text: "New", bgCssClass: "btn btn-default", handlerCssClass: "nnnn", fa_icon: 'fa fa-pencil', clickHandler: function (data) { alert("1: \n" + JSON.stringify(data)); } }, { text: "New", bgCssClass: "btn btn-danger", handlerCssClass: "bbb", fa_icon: 'fa fa-edit', clickHandler: function (data) { alert("2: \n" + JSON.stringify(data)); } }],
            customButtons: [],
            data: function (d) { return d; },
            createdRow: function (row, data, index) { },
            exportLink: options.exportLink,
            exportedColumns: options.exportedColumns,
            "info": true,
            columns: [],
            columnDefs: [],
            "searching": true,
            "ordering": true,
            "lengthChange": true,
            "lengthMenu": [[5, 10, 25, -1], ['5 سجلات', '10 سجلات', '25 سجلات', 'كل السجلات']],
            "pageLength": 10,
            order: (options.order) ?options.order: [0, "asc"],
            orientation: "portrait",
            initComplete: function () { }
        }, options);
        //---------------------------------------------

        if (settings.editBtn) {
            if (settings.editBtn.show) {

                default_edit_btn_html = "<button type='button' class='btn btn-sm btn-success btn-edit " + settings.editBtn.editButtonCssClass + "'><i class='fa fa-edit'></i> تعديل</button>";
                default_btns_html += default_edit_btn_html;
            }
        }

        if (settings.infoBtn) {
            if (settings.infoBtn.show) {
                default_info_btn_html = "<button type='button' class='btn btn-sm btn-info btn-details'><i class='fa fa-info'></i> تفاصيل</button>";
                default_btns_html += default_info_btn_html;
            }
        }

        if (settings.deleteBtn) {
            if (settings.deleteBtn.show) {
                default_delete_btn_html = "<button type='button' class='btn btn-sm btn-danger btn-delete " + settings.deleteBtn.deleteButtonCssClass + "'><i class='fa fa-trash'></i> حذف</button>";
                default_btns_html += default_delete_btn_html;
            }
        }
        if (settings.customButtons && settings.customButtons.length > 0) {
            $.each(settings.customButtons, function (key, button) {
                var newBtnHtml = "<button type='button' class='" + button.cssClass + "'><i class='" + button.fa_icon + "'></i> " + button.text + "</button>";
                default_btns_html += newBtnHtml;
            });
        }
        //---------------------------------------------
        var table;
        if (default_btns_html == "") {
            settings.columnDefs = [{
                "targets": -1,
                "data": null,
                "defaultContent": ""
            }];
        } else {
            settings.columnDefs = [{
                "targets": -1,
                "data": null,
                "defaultContent": "<div class = 'btn-group'>" + default_btns_html + "</div>"
            }];
        }
        var rendered = false;
        //alert(options.data);
        table = this.DataTable({
            //fixedColumns: false,
            "processing": true,
            "serverSide": true,
            "info": settings.info,
            "scrollX": settings.scrollX,
            "scrollY": settings.scrollY,
            "ajax": {
                "url": settings.ajaxReadUrl,
                "type": "post",
                "data": settings.data,
                "error": handleAjaxError
            },
            "order": settings.order,
            "ordering": settings.ordering,
            "searching": settings.searching,
            "lengthChange": settings.lengthChange,

            "columnDefs": settings.columnDefs,

            "lengthMenu": settings.lengthMenu,
            "createdRow": settings.createdRow,
            "pageLength": settings.pageLength,
            "columns": settings.columns,
            "drawCallback": function () {
                stopLoading();
                setTimeout(function () { table.columns.adjust(); }, 100);
                $(".dt-buttons").addClass("btn-group pull-left");
                try {
                    $(".buttons-excel").hide();
                    Export();
                } catch (ex) {
                }
                //$(".buttons-excel").off("click");
                //$(".buttons-excel").click(function () {
                //    //table.ajax.reload(null, false);
                //    table.page.len(50).draw();

                //});
            },
            "preDrawCallback": function (settings) {
                showLoading();
            },
            dom: 'Bfrtip',
            buttons: [
                {
                    //extend: 'excel',
                    text: '<span class="fa fa-file-excel-o"></span> تصدير',
                    action: function (e, dt, button, config) {
                        var win = window.open(settings.exportLink, '_blank');
                    },
                    className: 'btn btn-primary'
                },
                {
                    extend: 'excel',
                    text: '<button style="display: none !important;"><span class="fa fa-file-excel-o"></span> 263</button>',
                    exportOptions: {
                        columns: settings.exportedColumns
                    },
                    className: 'btn btn-primary'
                },
                {
                    extend: 'print',
                    text: '<span class="fa fa-print"></span> طباعة',
                    exportOptions: {
                        columns: settings.exportedColumns
                    },
                    className: 'btn btn-warning',
                    customize: function (win) {
                        $(win.document.body)
                            .css('font-size', '10pt')
                            .prepend('<div class="panel">' +
                                '<div class="row">' +
                                    '<div class="col-sm-6 text-right">' +
                                        '<h4>الجمهورية العربية السورية</h4>' +
                                        '<h5>القيادة العامة للجيش والقوات المسلحة</h5>' +
                                        '<h5>إدارة القوى البشرية</h5>' +
                                    '</div>' +

                                    //'<div class="col-sm-6 text-left">' +
                                    //    '<img src="/Content/Images/logo.png" style="width: 100px;height: 100px;" />' +
                                    //'</div>' +
                                '</div>' +
                                '</div>'
                            );
                        
                        $(win.document.body).find('table')
                            .addClass('compact')
                            .css('font-size', 'inherit');
                        $(win.document.body).find('h1')
                            .addClass('pageHeader');

                        
                        //var doc = new jsPDF({
                        //    orientation: settings.orientation,
                        //})
                        ////alert(win.document.body.outerHTML);
                        //doc.text(win.document.body.outerHTML, 10, 10);
                        //doc.save('two-by-four.pdf')

                        //html2pdf(document.body, pdf, function (pdf) {
                        //    var iframe = document.createElement('iframe');
                        //    iframe.setAttribute('style', 'position:absolute;right:0; top:0; bottom:0; height:100%; width:500px');
                        //    document.body.appendChild(iframe);
                        //    iframe.src = pdf.output('datauristring');
                        //});
                    },
                },
                //{
                //    text: '<button><span class="fa fa-pdf"></span> PDF</button>',
                //    exportOptions: {
                //        columns: settings.exportedColumns
                //    },
                //    action: function (e, dt, node, config) {
                        
                //        // Call the default csvHtml5 action method to create the CSV file
                //        $.fn.dataTable.ext.buttons.print.action.call(this, e, dt, node, config);
                //        return false;
                //    }
                //},
            ],
            language: {
                "decimal": "",
                "emptyTable": "لا يوجد أي سجل",
                "info": "النتائج من _START_ إلى _END_. الإجمالي:  _TOTAL_ سجل",
                "infoEmpty": "النتائح 0 إلى 0 من إجمالي 0 سجل",
                "infoFiltered": "(filtered from _MAX_ total entries)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "إظهار _MENU_ سجلات في الصفحة",
                "loadingRecords": "جاري التحميل",
                "processing": "جاري المعالجة",
                "search": "بحث:",
                "zeroRecords": "لم يتم العثور على نتائح تطابق بحثك",
                "paginate": {
                    "first": "الأولى",
                    "last": "الأخيرة",
                    "next": "التالية",
                    "previous": "السابقة"
                },
                "aria": {
                    "sortAscending": ": activate to sort column ascending",
                    "sortDescending": ": activate to sort column descending"
                }
            }
        });

        // Apply the search
        table.columns().every(function () {
            var that = this;
            $('input', this.footer()).on('keyup change', function () {
                if (that.search() !== this.value) {
                    that.search(this.value).draw();
                }
            });

        });

        //---------------------------------------------------------------
        if (settings.editBtn) {
            if (settings.editBtn.show) {
                if (settings.editBtn.clickHandler) {

                    table.tables().body().on('click', '.btn-edit', function () {
                        var data = table.row($(this).parents('tr')).data();
                        //var rowId = data.Id;
                        return editFunc(data, settings.editUrl, settings.containerModalId, settings.modalId, settings.disableModalClose); //settings.editBtn.clickHandler(data);
                    });
                }
            }
        }

        if (settings.infoBtn) {
            if (settings.infoBtn.show) {
                if (settings.infoBtn.clickHandler) {

                    table.tables().body().on('click', '.btn-details', function () {
                        var data = table.row($(this).parents('tr')).data();
                        //var rowId = data.Id;
                        return infoFunc(data, settings.infoUrl, settings.containerModalId, settings.modalId, settings.disableModalClose); //settings.infoBtn.clickHandler(data);
                    });
                }
            }
        }

        if (settings.deleteBtn) {
            if (settings.deleteBtn.show) {
                if (settings.deleteBtn.clickHandler) {

                    table.tables().body().on('click', '.btn-delete', function () {
                        var data = table.row($(this).parents('tr')).data();
                        //var rowId = data.Id;
                        return deleteFunc(data, settings.deleteUrl, settings.containerModalId, settings.modalId, settings.disableModalClose); //settings.deleteBtn.clickHandler(data);
                    });
                }
            }
        }

        if (settings.customButtons && settings.customButtons.length > 0) {
            var newBtnsCssClasses = [];
            $.each(settings.customButtons, function (key, button) {
                newBtnsCssClasses.push(button.handlerCssClass);
            });
            $.each(newBtnsCssClasses, function (index, cssClass) {
                table.tables().body().on('click', '.' + cssClass, function (e) {
                    e.preventDefault();
                    var data = table.row($(this).parents('tr')).data();
                    return settings.customButtons[index].clickHandler(data, e);
                });
            });
        }
        //---------------------------------------------------------------

        return table;
    };
    function handleAjaxError(xhr, textStatus, error) {
        //alert(error);
        stopLoading();
        console.log("textStatus: " + textStatus);
        console.log("error: " + error);
        //table.fnProcessingIndicator(false);
    }

    function editFunc(rowData, url, containerModalId, modalId, disableModalClose) {
        var rowId = rowData.id;
        showLoading();
        $.ajax({
            url: url,
            type: "GET",
            data: { id: rowId },
            success: function (response) {
                $(containerModalId).html(response);
                stopLoading();
                if (disableModalClose) {
                    $(modalId).modal({ backdrop: 'static', keyboard: false });
                } else {
                    $(modalId).modal();

                }
            },
            error: function (e1, e2, e3) {
                stopLoading();
            }
        });
    }

    function infoFunc(rowData, url, containerModalId, modalId, disableModalClose) {
        var rowId = rowData.id;
        showLoading();
        $.ajax({
            url: url,
            type: "GET",
            data: { id: rowId },
            success: function (response) {
                $(containerModalId).html(response);
                stopLoading();
                if (disableModalClose) {
                    $(modalId).modal({ backdrop: 'static', keyboard: false });
                } else {
                    $(modalId).modal();
                }
            },
            error: function (e1, e2, e3) {
                stopLoading();
            }
        });
    }

    function deleteFunc(rowData, url, containerModalId, modalId, disableModalClose) {
        var rowId = rowData.id;
        showLoading();
        $.ajax({
            url: url,
            type: "GET",
            data: { id: rowId },
            success: function (response) {
                $(containerModalId).html(response);
                stopLoading();
                if (disableModalClose) {
                    $(modalId).modal({ backdrop: 'static', keyboard: false });
                } else {
                    $(modalId).modal();
                }
            },
            error: function (e1, e2, e3) {
                stopLoading();
            }
        });
    }
}(jQuery));
