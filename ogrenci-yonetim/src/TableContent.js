import React, { Component } from "react";
import TblStudents from "./TblStudents";
import "antd/dist/antd.css";
import "./index.css";
import TblLessons from "./TblLessons";

function selectComponent(prmTableIndex) {
  console.log(prmTableIndex);
  switch (prmTableIndex) {
    case 1:
      return tableStudents();
    case 2:
      return tableLessons();
    default:
      return "Lütfen Menüden bir işlem seçiniz.";
  }
}
function tableStudents() {
  return <TblStudents></TblStudents>;
}
function tableLessons() {
  return <TblLessons></TblLessons>;
}

export default class TableContent extends Component {
  render() {
    return selectComponent(this.props.tableIndex);
  }
}
