angular.module('umbraco').controller('ProWorksInlineHtmlHelpLabelController', function($scope, assetsService, dialogService) {

	//--------------------------------------------------------------------------------------
	// Event Handlers
	//--------------------------------------------------------------------------------------

	/**
	 * @ngdoc method
	 * @name callbackFromDialog
	 * @function
	 * 
	 * @description
	 * Handles the result from the dialog view/controller
	 */
	$scope.callbackFromDialog = function (data) {

	};

	/**
	 * @ngdoc method
	 * @name openDialog
	 * @function
	 * 
	 * @description
	 * Opens the dialog via the Umbraco dialogService.
	 */
	$scope.openDialog = function () {

		dialogService.open({
			template: '/App_Plugins/ProWorksInlineHtmlHelpLabel/views/proworksmorehelpdialog.html',
			show: true,
			callback: $scope.callbackFromDialog,
			dialogData: $scope.model.config
		});

	};
});

// Controller for the dialog
angular.module('umbraco').controller('ProWorksInlineHtmlHelpLabelDialogController', function($scope, assetsService, dialogService) {


});