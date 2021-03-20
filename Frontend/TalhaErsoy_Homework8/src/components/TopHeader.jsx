const styles = {
    topHeader: {
      width: "100%",
      height: "5%",
    },
    text: {
      color: "#aaa",
      fontSize: 8,
      margin: 5,
    },
  };
  
  const TopHeader = ({name}) => {
  
    return(
      <div style={styles.topHeader}>
      <span style={styles.text}>{name}</span>
    </div>
    );
    
    }
  
  export default TopHeader;