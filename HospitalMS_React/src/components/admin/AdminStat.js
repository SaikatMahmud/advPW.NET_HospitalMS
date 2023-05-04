import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { Link, useNavigate } from "react-router-dom";
import { Chart } from "react-google-charts";

const AdminStat = () => {
  const [result, setResult] = useState([]);
  const [total, setTotal] = useState();
  const [isReady, setIsReady] = useState(false);
  const [cusAdd, setAddress] = useState("");
  const [method, setMethod] = useState("");
  const [errs, setErrs] = useState({});
  const [msgRemove, setRemove] = useState("");
  const navigate = useNavigate();

  //   const [currentYear, setCurrentYear] = useState([["Month", "TK"]]);
  //   const [previousYear, setPreviousYear] = useState([["Month", "TK"]]);
  const [OPDPtCount, setOPDPtCount] = useState([["Month", "Patient"]]);
  const [IPDPtCount, setIPDPtCount] = useState([["Month", "Patient"]]);
  const [OPDDoctorVisit, setOPDDoctorVisit] = useState([["Name", "Visit count"]]);
  const [OPDvsIPDrv, setOPDvsIPDrv] = useState([["Revenue Type", "Revenue Amount"]]);


  useEffect(() => {
    axiosConfig.get("/admin/stat").then((rsp) => {
      // setThisMonth(oldArray => [...oldArray,["Month", "TK"]]);
      setResult(rsp.data);
      rsp.data.OPDPtCount?.map((count, index) =>
        setOPDPtCount((oldArray) => [...oldArray, [count.Month, count.OPDPtCount]])
      )
      rsp.data.IPDPtCount?.map((count, index) =>
        setIPDPtCount((oldArray) => [...oldArray, [count.Month, count.IPDPtCount]])
      )
      rsp.data.OPDVisitDCount?.map((count, index) =>
        setOPDDoctorVisit((oldArray) => [...oldArray, [count.DoctorName, count.OPDVisitDCount]])
      )
      // setOPDvsIPDrv((oldArray) => [...oldArray,
      //   ["OPD revenue",result.OPDvsIPDCrntMn.CurrentMnOPDrv]
      //   ,["IPD revenue",result.OPDvsIPDCrntMn.CurrentMnIPDrv]])
      setOPDvsIPDrv(oldArray => [...oldArray, ["OPD revenue", rsp.data.OPDvsIPDCrntMn.CurrentMnOPDrv],
                                              ["IPD revenue", rsp.data.OPDvsIPDCrntMn.CurrentMnIPDrv]]);

      //   rsp.data.dataPreviousYear?.map((order,index)=>
      //   setPreviousYear((oldArray) => [...oldArray,[order.month,order.amount]])
      //   ) 

      setIsReady(true);
    }, (err) => {
      //setErrs(err.response.data);

    })

  }, []);


  if (!isReady) {
    return <h2 align="center">Page loading....</h2>
  }
  return (
    <div>
      {/* <div align='center'>
      Number of order placed from your account: <b>{result.count}</b><br/>
      Your total expense for all order: <b>{result.totalAmount}</b> TK<br/>
      </div> <br/>
      <div align='center'>
      Order placed in this month: <b>{result.countInThisM}</b><br/>
      Expense in this month: <b>{result.amountInThisM}</b> TK<br/>
      </div> <br/>
      <div align='center'>
      Order placed in previous month: <b>{result.countInPreviousM}</b><br/>
      Expense in previous month: <b>{result.amountInPreviousM}</b> TK<br/>
      </div> */}


      {/* {
        result.map((order, index) =>
        // setThisMonth.bind(oldArray => [...oldArray,[order.month,order.amount]])
        setThisMonth.push([order.month,order.amount])
        )
      } */}
      {

      }
      {/* 
      {console.log(currentYear)}

      <h4>Order statistics for current year:
      <Chart
        chartType="ColumnChart"
        data={currentYear}
        width="950px"
        height="300px"
        legendToggle
        sliceVisibilityThreshold='0'
      /></h4> */}
      <h4>Last 6 months OPD patient:
        <Chart
          chartType="ColumnChart"
          data={OPDPtCount}
          width="950px"
          height="300px"
          legendToggle
          sliceVisibilityThreshold='0'
        /></h4>

      <h4>Last 6 months IPD patient:
        <Chart
          chartType="ColumnChart"
          data={IPDPtCount}
          width="950px"
          height="300px"
          legendToggle
          sliceVisibilityThreshold='0'

        /></h4>
      <h4>Top 7 doctors with highest OPD patient:
        <Chart
          chartType="BarChart"
          data={OPDDoctorVisit}
          width="500px"
          height="300px"
          legendToggle
          sliceVisibilityThreshold='0'
        /></h4>
      <h4>Current month OPD vs IPD revenue:
        <Chart
          chartType="PieChart"
          data={OPDvsIPDrv}
          width="500px"
          height="300px"
          legendToggle
          sliceVisibilityThreshold='0'
        /></h4>
    </div>
  )
}

export default AdminStat