﻿using System.Collections.Generic;
using System.Data;

namespace InternalsViewer.Internals.Structures
{
    public abstract class Structure
    {
        private readonly List<Column> columns;
        private long allocationUnitId;
        private DataTable structureDataTable;
        private bool hasSparseColumns;

        public Structure(long allocationUnitId, Database database)
        {
            this.columns = new List<Column>();
            this.AllocationUnitId = allocationUnitId;
            this.StructureDataTable = this.GetStructure(allocationUnitId, database);
        }

        internal abstract void AddColumns(DataTable structure);

        public abstract DataTable GetStructure(long allocationUnitId, Database database);

        public long AllocationUnitId
        {
            get { return allocationUnitId; }
            set { allocationUnitId = value; }
        }

        public DataTable StructureDataTable
        {
            get { return structureDataTable; }
            set { structureDataTable = value; }
        }

        public List<Column> Columns
        {
            get { return columns; }
        }

        public bool HasSparseColumns
        {
            get { return this.hasSparseColumns; }
            set { this.hasSparseColumns = value; }
        }

    }
}
