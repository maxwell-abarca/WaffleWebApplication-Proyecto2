function Dashboard() {

    this.chartId = 'myChart';
    this.service = 'usuario';
    this.ctrlActions = new ControlActions();

    this.GetDataToChart = function (initializeChartFunction) {

        this.ctrlActions.Get(this.service + '?type=millenials', initializeChartFunction);
    };


}